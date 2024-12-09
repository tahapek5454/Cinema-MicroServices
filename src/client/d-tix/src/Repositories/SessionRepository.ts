import {AccessModify, HttpClientService, RequestParameters, ServerNames} from "@/services/HttpClientService";
import PreBookingRequest from "@/models/session/PreBookingRequest";
import SeatSessionStatusDto from "@/models/session/SeatSessionStatusDto";
import SessionDto from "@/models/session/SessionDto";
import SeatDto from "@/models/session/SeatDto";

export class SessionRepository extends  HttpClientService{
    protected readonly stableRequestParameter: RequestParameters = {
        controller: "Sessions",
        serverName: ServerNames.SessionServer
    }

    async  PreBookingOrCancel(request: Partial<PreBookingRequest>){
        await this.postAsync({
            ...this.stableRequestParameter,
            accessModify: AccessModify.Public,
            action: "PreBookingOrCancel"
        }, request);
    }

    async GetSeatWithStatusBySessionId(id:number):Promise<SeatSessionStatusDto[]>{
        const result = await this.getAsync<SeatSessionStatusDto[]>({
            ...this.stableRequestParameter,
            accessModify: AccessModify.Public,
            action: "GetSeatWithStatusBySessionId"
        },id.toString());

        return result;
    }

    async  GetAllSessionsByBranchAndMovieId(branchId: number, movieId: number){
        const result = await  this.getAsync<SessionDto[]>({
            ...this.stableRequestParameter,
            accessModify: AccessModify.Public,
            action: "GetAllSessionsByBranchAndMovieId",
            queryString:`branchId=${branchId}&movieId=${movieId}`
        });

        return result;
    }


    async GetSessionById(sessionId: number){
        const result = await  this.getAsync<SessionDto>({
           ...this.stableRequestParameter,
           accessModify: AccessModify.Public,
           action: "GetSessionById"
        },''+sessionId);
        return result
    }

    async GetSeatsBySessionIdAndUserId(userId: number, sessionId: number){

        if(!userId || !sessionId)
            throw new Error("Parametreler geçersiz.");

        const result = await  this.getAsync<SeatDto[]>({
            ...this.stableRequestParameter,
            accessModify: AccessModify.Public,
            action: "GetSeatsBySessionIdAndUserId",
            queryString:`userId=${userId}&sessionId=${sessionId}`
        });

        return result;
    }
}