import { MovieRepository } from "@/Repositories/MovieRepository";

export function RepositoryFactory(repository: Repositories){

    switch (repository) {
        case Repositories.MovieRepository: 
            return new MovieRepository();
    
        default:
            break;
    }
}


export enum Repositories{
    MovieRepository
}