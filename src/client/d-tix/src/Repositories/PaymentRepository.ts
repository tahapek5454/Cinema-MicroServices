
import { AccessModify, HttpClientService, RequestParameters, ServerNames } from "@/services/HttpClientService";

export class PaymentRepository extends HttpClientService{

    readonly stableRequestParameter: RequestParameters = {
        controller: "Payments",
        serverName: ServerNames.PaymentServer
    }

    

    async PayProduct(name: string): Promise<any>{
         const result =  await this.postAsync({
            ...this.stableRequestParameter,
            accessModify: AccessModify.Public,
            action: "PayProduct"
        }, {name :name});

        return result;
    }
    
}