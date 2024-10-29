import AssistantRequest from "@/models/Assistant/AssistantRequest";
import AssistantResponse from "@/models/Assistant/AssistantResponse";
import { AccessModify, HttpClientService, RequestParameters, ServerNames } from "@/services/HttpClientService";

export class AssistantRepository extends HttpClientService{
    private readonly stableRequestParameter: RequestParameters = {
        controller: "Ai",
        serverName: ServerNames.AiServer
    }

    async MovieAssistant(request: Partial<AssistantRequest>):Promise<AssistantResponse>{
        
        const response:AssistantResponse = await this.postAsync<AssistantRequest,AssistantResponse>({
            ...this.stableRequestParameter,
            accessModify: AccessModify.Public,
            action: "MovieAssistant"
        }, request);

        return response;
    }
}