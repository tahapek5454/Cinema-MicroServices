
import { AccessModify, HttpClientService, RequestParameters, ServerNames } from "@/services/HttpClientService";
import ReservationRequest from "@/models/reservation/ReservationRequest";

export class PaymentRepository extends HttpClientService{

    readonly stableRequestParameter: RequestParameters = {
        controller: "Payments",
        serverName: ServerNames.PaymentServer
    }

    

    async PayProduct(body: Partial<ReservationRequest>): Promise<any>{
         const result =  await this.postAsync({
            ...this.stableRequestParameter,
            accessModify: AccessModify.Public,
            action: "PayProduct"
        }, body);

        return result;
    }
    
}