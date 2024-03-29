﻿using Cinema.Services.MovieAPI.Data.Contexts;
using Cinema.Services.MovieAPI.Models.Entities;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Events.MovieImageEvents;

namespace Cinema.Services.MovieAPI.Consumers
{
    public class MovieImageDeletedEventConsumer(AppDbContext _appDbContext) : IConsumer<MovieImageDeletedEvent>
    {
        public async Task Consume(ConsumeContext<MovieImageDeletedEvent> context)
        {
            var image = await _appDbContext.Set<MovieImage>().FirstOrDefaultAsync(x => x.FileName.Equals(context.Message.FileName));

            if (image == null)
                return;

            _appDbContext.Remove(image);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
