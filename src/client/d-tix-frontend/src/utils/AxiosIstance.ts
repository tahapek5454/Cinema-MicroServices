import type { BlankDto } from "@/repositories/models/BlankDto";
import type { ErrorDto } from "@/repositories/models/ErrorDto";
import type { ResponseDto } from "@/repositories/models/ResponseDto";
import axios, { AxiosError } from "axios";
import dayjs from "dayjs";
import { jwtDecode } from "jwt-decode";


const baseURL = 'https://localhost:7291';
const loginUrl = '/api/Auth/login';


let authValues: any = localStorage.getItem('authValues') ? JSON.parse(localStorage.getItem('authValues') as string) : null;


const axiosInstance = axios.create({
    baseURL: baseURL,
    headers: { Authorization: `Bearer ${authValues?.accessToken}`, 'support_language': 'tr_TR' }
})


axiosInstance.interceptors.request.use(async req => {

    if (req.url == loginUrl) // araya girmeye gerek yok zaten token almaya calisiyoruz
        return req;

    if (!authValues || !authValues?.accessToken) {
        authValues = localStorage.getItem('authValues') ? JSON.parse(localStorage.getItem('authValues') as string) : null;
        req.headers.Authorization = `Bearer ${authValues?.accessToken}`
    }

    if (authValues && authValues.accessToken) { // bu kontrol manuel local storage'den sildiysek eğer refres kısmına istek atmaya gerek olmadığından koyuldu
        const user = jwtDecode(authValues.accessToken);
        const isExpired = dayjs.unix(user.exp as number).diff(dayjs()) < 1;
        if (!isExpired)
            return req;


        try {
            const response = await axios.post(baseURL + '/api/Auth/RefreshToken', { RefreshToken: authValues?.refreshToken })
            console.log('Yazicaz');
            localStorage.setItem('authValues', JSON.stringify(response.data.data));
            req.headers.Authorization = `Bearer ${response.data.data?.accessToken}`;
            
        } catch (error) {
            console.log("Refresh Sırasında hata alindi.");
        }
    }

    return req;
}, (error: any) => {

    console.log(error.response);

    return Promise.reject(error);
})


axiosInstance.interceptors.response.use((response) => response /* success operation */
    , (error: any) => {

        const isShow = error?.response?.data?.error?.IsShow ?  error?.response?.data?.error?.IsShow : false;
        const message = error?.response?.data?.error?.Errors  &&  error?.response?.data?.error?.Errors.length > 0 ? error?.response?.data?.error?.Errors[0] : '';


        if(isShow)
            console.log(message);
    

        // if(errValue.IsShow){
        //     console.log(errValue.Errors && errValue.Errors[0]);
        // }
         
            

        if(error.response?.status === 404) // Not Found ekranina gitr
            return Promise.reject(error);
        if(error.response?.status === 401) // login ekranina git
            return Promise.reject(error);

        return Promise.reject(error);
    });


export default axiosInstance; 


