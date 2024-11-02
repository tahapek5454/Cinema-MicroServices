﻿using Cinema.Services.MovieAPI.Application.Dtos.Categories;
using Cinema.Services.MovieAPI.Application.Dtos.Comments;
using Cinema.Services.MovieAPI.Application.Dtos.Files;

namespace Cinema.Services.MovieAPI.Application.Dtos.Movies
{
    public class MovieDto
    {
        public MovieDto()
        {
            MovieImages = new();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Point { get; set; }
        public double Time { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
        public List<MovieImageDto> MovieImages { get; set; }
        public List<MovieCommentDto> MovieComments { get; set; }
    }
}
