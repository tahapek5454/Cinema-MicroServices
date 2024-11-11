import DistrinctDto from "@/models/distrinct/DistrinctDto";
import { AccessModify, HttpClientService, RequestParameters, ServerNames } from "@/services/HttpClientService";

export class DistrinctRepository extends HttpClientService {

    readonly stableRequestParameter: RequestParameters = {
        controller: "Ditricts",
        serverName: ServerNames.BranchServer
    }

    async GetDistrictByCity(CityId: string): Promise<DistrinctDto[]> {
        const result: DistrinctDto[] = await this.getAsync({
            ...this.stableRequestParameter,
            accessModify: AccessModify.Public,
            action: "GetDistrictByCity",
            queryString: `CityId=${CityId}`
        });

        return result;
    }
}