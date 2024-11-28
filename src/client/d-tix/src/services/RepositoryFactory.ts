import { AssistantRepository } from "@/Repositories/AssistantRepository";
import { MovieRepository } from "@/Repositories/MovieRepository";
import { PaymentRepository } from "@/Repositories/PaymentRepository";
import { AuthRepository } from "@/Repositories/AuthRepository";
import { SessionRepository } from "@/Repositories/SessionRepository";
import { BranchRepository } from "@/Repositories/BranchRepository";
import { CategoryRepository } from "@/Repositories/CategoryRepository";
import { CityRepository } from "@/Repositories/CityRepository";
import { DistrinctRepository } from "@/Repositories/DistrinctRepository";

export function RepositoryFactory(repository: Repositories) {

    switch (repository) {
        case Repositories.MovieRepository:
            return new MovieRepository();
        case Repositories.AssistantRepository:
            return new AssistantRepository();
        case Repositories.PaymentRepository:
            return new PaymentRepository();
        case Repositories.AuthRepository:
            return new AuthRepository();
        case Repositories.SessionRepository:
            return new SessionRepository();
        case Repositories.BranchRepository:
            return new BranchRepository();
        case Repositories.CategoryRepository:
            return new CategoryRepository();
        case Repositories.CityRepository:
            return new CityRepository();
        case Repositories.DistrinctRepository:
            return new DistrinctRepository();
        default:
            break;
    }
}


export enum Repositories {
    MovieRepository,
    AssistantRepository,
    PaymentRepository,
    AuthRepository,
    SessionRepository,
    BranchRepository,
    CategoryRepository,
    CityRepository,
    DistrinctRepository
}