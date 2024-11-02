﻿using SharedLibrary.Models.Entities;

namespace Cinema.Services.MovieAPI.Domain.Entities
{
    public class Movie : BaseEntity
    {
        public string Name { get; set; }
        public string? Name_EN { get; set; }
        public string Description { get; set; }
        public string? Description_EN { get; set; }
        public double Point { get; set; }
        public double Time { get; set; }
        public int CategoryId { get; set; }
        public List<MovieImage> MovieImages { get; set; }
        public List<MovieComment> MovieComments { get; set; }
    }
}
