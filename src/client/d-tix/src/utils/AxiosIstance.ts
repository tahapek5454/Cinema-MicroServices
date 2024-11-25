import axios from "axios";
import dayjs from "dayjs";
import { jwtDecode } from "jwt-decode";
import Vue from "vue";
import {GetAuthInfo, RemoveAuthInfo} from "@/services/AuthService";
import router from "@/router";
import {Bus} from "@/utils/Bus";


const baseURL = 'https://localhost:7135';
const baseAuthUrl = 'https://localhost:7291';
const loginUrl = 'authserver/public/api/Auth/Login';


let authValues = GetAuthInfo();

const axiosInstance = axios.create({
    baseURL: baseURL,
    headers: { Authorization: `Bearer ${authValues!=null ? authValues?.accessToken : ''}`, 'support_language': 'tr_TR' }
})


axiosInstance.interceptors.request.use(async req => {
    if (req.url == loginUrl) // araya girmeye gerek yok zaten token almaya calisiyoruz
        return req;

    if (!authValues
        || !authValues?.accessToken
        || (typeof  axiosInstance.defaults.headers["Authorization"] == "string" && axiosInstance.defaults.headers["Authorization"].length < 20)
        || (typeof req.headers.Authorization == "string" && req.headers.Authorization.length < 20)) {
        authValues = GetAuthInfo();
        req.headers.Authorization = `Bearer ${authValues!=null ? authValues?.accessToken : ''}`;
        axiosInstance.defaults.headers["Authorization"] = `Bearer ${authValues!=null ? authValues?.accessToken : ''}`; // degistirdik neden cunku login olunca base degismiyordu
    }

    if (authValues && authValues.accessToken) { // bu kontrol manuel local storage'den sildiysek eğer refres kısmına istek atmaya gerek olmadığından koyuldu
        const user = jwtDecode(authValues.accessToken);
        const isExpired = dayjs.unix(user.exp as number).diff(dayjs()) < 1;
        console.log("expire : ", isExpired)
        if (!isExpired)
            return req;


        try {
            const response = await axios.post(baseAuthUrl + '/api/Auth/RefreshToken', { RefreshToken: authValues?.refreshToken })
            localStorage.setItem('authValues', JSON.stringify(response.data));
            authValues = GetAuthInfo();
            req.headers.Authorization = `Bearer ${response.data.data?.accessToken}`;
            axiosInstance.defaults.headers["Authorization"] = `Bearer ${authValues!=null ? authValues?.accessToken : ''}`;
            
        } catch (error) {
            console.log("Refresh Sırasında hata alindi.");
            Vue.$toast.error("Refresh Sırasında hata alindi.");
        }finally {
            Vue.$toast.warning("Refreshe Gidildi.");
        }
    }

    return req;
}, (error: any) => {

    console.log(error.response);

    return Promise.reject(error);
})


axiosInstance.interceptors.response.use((response) => response /* success operation */
    , (error: any) => {
        // const toastifyService: ToastifyService = new ToastifyService();
        const isShow = error?.response?.data?.error?.IsShow ?  error?.response?.data?.error?.IsShow : false;
        const message = error?.response?.data?.error?.Errors  &&  error?.response?.data?.error?.Errors.length > 0 ? error?.response?.data?.error?.Errors[0] : '';

        if(isShow)  Vue.$toast.error(message);


        if(error.response?.status === 404) // Not Found ekranina gitr
            return Promise.reject(error);
        if(error.response?.status === 401) // login ekranina git
        {
            Bus.$emit("logout");
            router.push("/auth");
            Vue.$toast.error("Devam etmek için lütfen giriş yapınız 🤗");
            return Promise.reject(error);
        }
        if(error.response?.status === 403){
            Bus.$emit("logout");
            router.push("/auth");
            Vue.$toast.error("Devam etmek için yetkili bir hesaba geçiş yapınız 🤗");
            return Promise.reject(error);
        }


        return Promise.reject(error);
    });


export default axiosInstance; 


