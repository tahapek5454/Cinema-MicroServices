import AddBranchRequest from "@/models/branch/AddBranchRequest";
import BranchDto from "@/models/branch/BranchDto";

import { AccessModify, HttpClientService, RequestParameters, ServerNames } from "@/services/HttpClientService";

export class BranchRepository extends HttpClientService{

    readonly stableRequestParameter: RequestParameters = {
        controller: "Branchs",
        serverName: ServerNames.BranchServer
    }

    async GetAllBranches(): Promise<BranchDto[]>{
        const result : BranchDto[] = await this.getAsync({
            ...this.stableRequestParameter,
            accessModify: AccessModify.Public,
            action: "GetAllBranches",
        });
        
        return result;
    }

    async GetBranches():Promise<BranchDto>{
        const result : BranchDto = await this.getAsync({
            ...this.stableRequestParameter,
            accessModify: AccessModify.Public,
            action: "GetBranches",
        });

        return result;
    }

    async GetBrancheById(Id:string):Promise<BranchDto>{
        const result : BranchDto = await this.getAsync({
            ...this.stableRequestParameter,
            accessModify: AccessModify.Public,
            action: "GetBrancheById",
        }, Id);

        return result;
    }

    async GetBranchesByDistrinct(Id: string):Promise<BranchDto[]>{
        const result : BranchDto[] = await this.getAsync({
            ...this.stableRequestParameter,
            accessModify: AccessModify.Public,
            action: "GetBranchesByDistrinct",
            queryString: `DistrinctId=${Id}`
        });

        return result;
    }

    async AddBranch(request: Partial<AddBranchRequest>): Promise<void>{
        await this.postAsync({
            ...this.stableRequestParameter,
            accessModify: AccessModify.Private,
            action: "AddBranch"
        }, request);
    }
}