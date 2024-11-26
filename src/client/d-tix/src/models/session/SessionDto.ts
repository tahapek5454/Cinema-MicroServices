import MovieTheaterDto from "@/models/movieTheater/MovieTheaterDto";

export  default  class SessionDto {
    id: number;
    movieId: number;
    movieTheaterId: number;
    movieTheater: MovieTheaterDto;
    date: Date;
    price: number;
}