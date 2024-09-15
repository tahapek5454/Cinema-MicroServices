using Cinema.Services.MovieAPI.Application.Services.Abstract;
using Cinema.Services.MovieAPI.Domain.Entities;
using Cinema.Services.MovieAPI.Infrastructure.Services.Concrete;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Events.MovieImageEvents;

namespace Cinema.Services.MovieAPI.Infrastructure.Consumers
{
    public class MovieImageDeletedEventConsumer(IMovieImageService _movieImageService, MovieUnitOfWork _movieUnitOfWork) : IConsumer<MovieImageDeletedEvent>
    {
        public async Task Consume(ConsumeContext<MovieImageDeletedEvent> context)
        {
            var image = await _movieImageService.Table.FirstOrDefaultAsync(x => x.FileName.Equals(context.Message.FileName));

            if (image == null)
                return;

            _movieImageService.Table.Remove(image);
            await _movieUnitOfWork.SaveChangesAsync();
        }
    }
}
