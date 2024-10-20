using Cinema.Services.MovieAPI.Application.Mapper;
using Cinema.Services.MovieAPI.Application.Services.Abstract;
using Cinema.Services.MovieAPI.Domain.Entities;
using Cinema.Services.MovieAPI.Infrastructure.Services.Concrete;
using MassTransit;
using SharedLibrary.Events.MovieImageEvents;
using SharedLibrary.Repositories.SharedModelRepositories.Abstract;
using SharedLibrary.Settings;

namespace Cinema.Services.MovieAPI.Infrastructure.Consumers
{
    public class MovieImageUploadedEventConsumer(IMovieImageService _movieImageService, MovieUnitOfWork _movieUnitOfWork, ISharedMovieRepository _sharedMovieRepository, ISendEndpointProvider _sendEndpointProvider) : IConsumer<MovieImageUploadedEvent>
    {
        public async Task Consume(ConsumeContext<MovieImageUploadedEvent> context)
        {
            MovieImage? newMovieFile = ObjectMapper.Mapper.Map<MovieImage>(context.Message);
            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint
                   (new Uri($"queue:{RabbitMQSettings.FileStateMachineQueue}"));
            if (newMovieFile != null)
            {
                await _movieImageService.AddAsync(newMovieFile);
                await _movieUnitOfWork.SaveChangesAsync();

                var sharedMovie = await _sharedMovieRepository.GetByIdAsync(context.Message.RelationId);

                if(sharedMovie is not null)
                {
                    sharedMovie.MovieImages ??= new();

                    sharedMovie.MovieImages.Add(new()
                    {
                        FileName = newMovieFile.FileName,
                        Id = newMovieFile.Id,
                        MovieId = newMovieFile.MovieId,
                        Path = newMovieFile.Path,
                        Storage = newMovieFile.Storage
                    });
                }

                MovieImageReceivedEvent movieImageReceivedEvent = new(context.Message.CorrelationId);

                await sendEndpoint.Send(movieImageReceivedEvent);
            }
            else
            {
                MovieImageNotReceivedEvent movieImageNotReceivedEvent = new(context.Message.CorrelationId)
                {
                    FileId = context.Message.FileId,
                    Message = "Movie could not received.",
                    FileName = context.Message.FileName
                };

                await sendEndpoint.Send(movieImageNotReceivedEvent);
            }

        }
    }
}
