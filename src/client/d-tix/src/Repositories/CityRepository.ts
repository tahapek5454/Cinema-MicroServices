import CityDto from "@/models/city/CityDto";
import { AccessModify, HttpClientService, RequestParameters, ServerNames } from "@/services/HttpClientService";

export class CityRepository extends HttpClientService {

    readonly stableRequestParameter: RequestParameters = {
        controller: "Cities",
        serverName: ServerNames.BranchServer
    }

    async GetAllCities(): Promise<CityDto[]> {
        const result: CityDto[] = await this.getAsync({
            ...this.stableRequestParameter,
            accessModify: AccessModify.Public,
            action: "GetAllCities",
        });

        return result;
    }
}