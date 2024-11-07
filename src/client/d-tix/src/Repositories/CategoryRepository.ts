import AddBranchRequest from "@/models/branch/AddBranchRequest";
import BranchDto from "@/models/branch/BranchDto";
import AddCategoryRequest from "@/models/categories/AddCategoryRequest";
import CategoryDto from "@/models/categories/CategoryDto";
import UpdateCategoryRequest from "@/models/categories/UpdateCategoryRequest";

import { AccessModify, HttpClientService, RequestParameters, ServerNames } from "@/services/HttpClientService";

export class CategoryRepository extends HttpClientService{

    readonly stableRequestParameter: RequestParameters = {
        controller: "Categories",
        serverName: ServerNames.BranchServer
    }

    async GetCategoryById(Id:string):Promise<CategoryDto>{
        const result : CategoryDto = await this.getAsync({
            ...this.stableRequestParameter,
            accessModify: AccessModify.Public,
            action: "GetCategoryById",
        }, Id);

        return result;
    }

    async GetCategoriesWithPagination(Page:number=1, Size:number=10): Promise<CategoryDto>{

        const result : CategoryDto = await this.getAsync({
            ...this.stableRequestParameter,
            accessModify: AccessModify.Public,
            action: "GetCategoriesWithPagination",
            queryString: `Page=${Page}&Size=${Size}`
        });

        return result;
    }

    async GetAllCategories():Promise<CategoryDto[]>{
        const result : CategoryDto[] = await this.getAsync({
            ...this.stableRequestParameter,
            accessModify: AccessModify.Public,
            action: "GetAllCategories",
        });

        return result;
    }

    async AddCategory(request: Partial<AddCategoryRequest>): Promise<void>{
        await this.postAsync({
            ...this.stableRequestParameter,
            accessModify: AccessModify.Private,
            action: "AddCategory"
        }, request);
    }

    async UpdateGategory(request: Partial<UpdateCategoryRequest>): Promise<void>{
        await this.putAsync({
            ...this.stableRequestParameter,
            accessModify: AccessModify.Private,
            action: "UpdateGategory"
        }, request);
    }

    async RemoveGategory(Id: string): Promise<void>{
        await this.putAsync({
            ...this.stableRequestParameter,
            accessModify: AccessModify.Private,
            action: "RemoveGategory"
        }, Id);
    }
}