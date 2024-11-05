import LoginResponse from "@/models/auth/LoginResponse";

export function  GetAuthInfo():LoginResponse | null{
    const authValue =
        localStorage.getItem('authValues') &&  localStorage.getItem('authValues') != undefined && localStorage.getItem('authValues') != 'undefined'
        ? JSON.parse(localStorage.getItem('authValues') as string)
            : null;

    return  authValue;
}

export function RemoveAuthInfo(){
    localStorage.removeItem('authValues');
}