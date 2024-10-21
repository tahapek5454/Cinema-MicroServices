import CategoryDto from "../categories/CategoryDto";
import { MovieImageDto } from "../images/MovieImageDto";

export default class MovieDto{
    id: number;
    name: string;
    description: string;
    point: number;
    time: number;
    createdDate: Date;
    updatedDate: Date;
    categoryId: number;
    category: CategoryDto;
    movieImages: MovieImageDto[];
}