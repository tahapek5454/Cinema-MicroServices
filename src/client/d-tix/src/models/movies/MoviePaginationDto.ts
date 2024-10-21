import MovieDto from "./MovieDto";

export default class MoviePaginationDto{
    data: MovieDto[];
    totalCount: number;
}