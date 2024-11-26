import {AccessModify, HttpClientService, RequestParameters, ServerNames} from "@/services/HttpClientService";
import PreBookingRequest from "@/models/session/PreBookingRequest";
import SeatSessionStatusDto from "@/models/session/SeatSessionStatusDto";
import SessionDto from "@/models/session/SessionDto";

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
        debugger;
        const result = await  this.getAsync<SessionDto>({
            ...this.stableRequestParameter,
            accessModify: AccessModify.Public,
            action: "GetAllSessionsByBranchAndMovieId",
            queryString:`branchId=${branchId}&movieId=${movieId}`
        });

        return result;
    }
}