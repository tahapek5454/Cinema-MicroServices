﻿using Cinema.Services.MovieAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Services;

namespace Cinema.Services.MovieAPI.Services.Abstract
{
    public interface IMovieImageService: IBaseService
    {
        public DbSet<MovieImage> Table { get; }
        public Task<int> SaveChangesAsync();
        public int SaveChanges();
    }
}
