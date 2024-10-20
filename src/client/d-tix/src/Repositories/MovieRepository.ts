import AddMovieRequest from "@/models/movies/AddMovieRequest";
import MovieDto from "@/models/movies/MovieDto";
import MoviePaginationDto from "@/models/movies/MoviePaginationDto";

import UpdateMovieRequest from "@/models/movies/UpdateMovieRequest";
import { AccessModify, HttpClientService, RequestParameters, ServerNames } from "@/services/HttpClientService";

export class MovieRepository extends HttpClientService{

    readonly stableRequestParameter: RequestParameters = {
        controller: "Movies",
        serverName: ServerNames.MovieServer
    }

    async GetMovieById(Id:string): Promise<MovieDto>{
        const result : MovieDto = await this.getAsync({
            ...this.stableRequestParameter,
            accessModify: AccessModify.Public,
            action: "GetMovieById",
        }, Id);
        
        return result;
    }

    async GetMoviesWithPagination(Page:number, Size:number): Promise<MoviePaginationDto>{

        const result : MoviePaginationDto = await this.getAsync({
            ...this.stableRequestParameter,
            accessModify: AccessModify.Public,
            action: "GetMoviesWithPagination",
            queryString: `Page=${Page}&Size=${Size}`
        });

        return result;
    }

    async GetAllMovies():Promise<MovieDto[]>{
        const result : MovieDto[] = await this.getAsync({
            ...this.stableRequestParameter,
            accessModify: AccessModify.Public,
            action: "GetAllMovies",
        });

        return result;
    }

    async AddMovie(request: Partial<AddMovieRequest>): Promise<void>{
        await this.postAsync({
            ...this.stableRequestParameter,
            accessModify: AccessModify.Private,
            action: "AddMovie"
        }, request);
    }


    async UpdateMovie(request: Partial<UpdateMovieRequest>): Promise<void>{
        await this.putAsync({
            accessModify: AccessModify.Private,
            action: "UpdateMovie"
        }, request);
    }

    async RemoveMovie(Id: string): Promise<void>{
        await this.deleteAsync({
            accessModify: AccessModify.Private,
            action: "RemoveMovie"
        }, Id);
    }
}