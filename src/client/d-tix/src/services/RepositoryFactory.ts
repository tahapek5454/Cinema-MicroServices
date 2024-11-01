import { AssistantRepository } from "@/Repositories/AssistantRepository";
import { MovieRepository } from "@/Repositories/MovieRepository";
import { AuthRepository } from "@/Repositories/AuthRepository";

export function RepositoryFactory(repository: Repositories) {

    switch (repository) {
        case Repositories.MovieRepository:
            return new MovieRepository();
        case Repositories.AssistantRepository:
            return new AssistantRepository();
        case Repositories.AuthRepository:
            return new AuthRepository();
        default:
            break;
    }
}


export enum Repositories {
    MovieRepository,
    AssistantRepository,
    AuthRepository
}