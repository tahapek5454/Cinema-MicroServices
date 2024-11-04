import { AssistantRepository } from "@/Repositories/AssistantRepository";
import { MovieRepository } from "@/Repositories/MovieRepository";
import { AuthRepository } from "@/Repositories/AuthRepository";
import {SessionRepository} from "@/Repositories/SessionRepository";

export function RepositoryFactory(repository: Repositories) {

    switch (repository) {
        case Repositories.MovieRepository:
            return new MovieRepository();
        case Repositories.AssistantRepository:
            return new AssistantRepository();
        case Repositories.AuthRepository:
            return new AuthRepository();
        case Repositories.SessionRepository:
            return new SessionRepository();
        default:
            break;
    }
}


export enum Repositories {
    MovieRepository,
    AssistantRepository,
    AuthRepository,
    SessionRepository   ,
}