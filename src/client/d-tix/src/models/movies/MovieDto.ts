import CategoryDto from "../categories/CategoryDto";
import { MovieImageDto } from "../images/MovieImageDto";

export default class MovieDto{
    Id: number;
    Name: string;
    Description: string;
    Point: number;
    Time: number;
    CreatedDate: Date;
    UpdatedDate: Date;
    CategoryId: number;
    Category: CategoryDto;
    MovieImages: MovieImageDto[];
}