import { AssistantRepository } from "@/Repositories/AssistantRepository";
import { MovieRepository } from "@/Repositories/MovieRepository";

export function RepositoryFactory(repository: Repositories){

    switch (repository) {
        case Repositories.MovieRepository: 
            return new MovieRepository();
        case Repositories.AssistantRepository:
            return new AssistantRepository();
        default:
            break;
    }
}


export enum Repositories{
    MovieRepository,
    AssistantRepository
}