import LoginRequest from "@/models/auth/LoginRequest";
import RegisterRequest from "@/models/auth/RegisterRequest";
import MovieDto from "@/models/movies/MovieDto";

import { AccessModify, HttpClientService, RequestParameters, ServerNames } from "@/services/HttpClientService";

export class AuthRepository extends HttpClientService{

    readonly stableRequestParameter: RequestParameters = {
        controller: "Auth",
        serverName: ServerNames.AuthServer
    }

    async Login(loginRequest:LoginRequest): Promise<MovieDto>{
        const result : MovieDto = await this.postAsync({
            ...this.stableRequestParameter,
            accessModify: AccessModify.Public,
            action: "Login",
        }, loginRequest);
        
        return result;
    }

    async Register(registerRequest:RegisterRequest): Promise<MovieDto>{
        const result : MovieDto = await this.postAsync({
            ...this.stableRequestParameter,
            accessModify: AccessModify.Public,
            action: "Register",
        }, registerRequest);
        
        return result;
    }
}
