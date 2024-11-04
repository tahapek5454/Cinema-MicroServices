import {AccessModify, HttpClientService, RequestParameters, ServerNames} from "@/services/HttpClientService";
import PreBookingRequest from "@/models/session/PreBookingRequest";

export class SessionRepository extends  HttpClientService{
    readonly stableRequestParameter: RequestParameters = {
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
}