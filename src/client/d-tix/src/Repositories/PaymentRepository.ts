
import { AccessModify, HttpClientService, RequestParameters, ServerNames } from "@/services/HttpClientService";

export class PaymentRepository extends HttpClientService{

    readonly stableRequestParameter: RequestParameters = {
        controller: "Payments",
        serverName: ServerNames.PaymentServer
    }



    async PayProduct(name: string): Promise<any>{
        await this.postAsync({
            ...this.stableRequestParameter,
            accessModify: AccessModify.Private,
            action: "PayProduct"
        }, name);
    }

}