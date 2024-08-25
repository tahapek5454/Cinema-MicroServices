import axios from "axios";
import dayjs from "dayjs";
import { jwtDecode } from "jwt-decode";


const baseURL = 'https://localhost:7291';
const loginUrl = '/api/Auth/login';


let authValues: any = localStorage.getItem('authValues') ? JSON.parse(localStorage.getItem('authValues') as string)  : null; 


const axiosInstance = axios.create({
    baseURL: baseURL,
    headers: {Authorization: `Bearer ${authValues?.accessToken}`, 'support_language': 'tr_TR'}
})


axiosInstance.interceptors.request.use(async req => {

    if(req.url == loginUrl) // araya girmeye gerek yok zaten token almaya calisiyoruz
        return req;

    if(!authValues || !authValues?.accessToken){
        authValues = localStorage.getItem('authValues') ? JSON.parse(localStorage.getItem('authValues') as string)  : null; 
        req.headers.Authorization = `Bearer ${authValues?.accessToken}`
    }

    if(authValues && authValues.accessToken){ // bu kontrol manuel local storage'den sildiysek eğer refres kısmına istek atmaya gerek olmadığından koyuldu
        const user = jwtDecode(authValues.accessToken);
        const isExpired = dayjs.unix(user.exp as number).diff(dayjs()) < 1;
        if(!isExpired)
            return req;


        await axios.post(baseURL+'/api/Auth/RefreshToken', {RefreshToken: authValues?.refreshToken})
                    .then((response)=>{
                        localStorage.setItem('authValues', JSON.stringify(response.data.data));
                        req.headers.Authorization = `Bearer ${response.data.data?.accessToken}`
                    });
    }

    return req;
})


export default axiosInstance; 