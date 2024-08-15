using Cinema.Services.MovieAPI.Application.Mapper;
using Cinema.Services.MovieAPI.Domain.Entities;
using Cinema.Services.MovieAPI.Persistence.Data.Contexts;
using MassTransit;
using SharedLibrary.Events.MovieImageEvents;
using SharedLibrary.Settings;

namespace Cinema.Services.MovieAPI.Infrastructure.Consumers
{
    public class MovieImageUploadedEventConsumer(AppDbContext _appDbContext, ISendEndpointProvider _sendEndpointProvider) : IConsumer<MovieImageUploadedEvent>
    {
        public async Task Consume(ConsumeContext<MovieImageUploadedEvent> context)
        {
            MovieImage? newMovieFile = ObjectMapper.Mapper.Map<MovieImage>(context.Message);
            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint
                   (new Uri($"queue:{RabbitMQSettings.FileStateMachineQueue}"));
            if (newMovieFile != null)
            {
                await _appDbContext.Set<MovieImage>().AddAsync(newMovieFile);
                await _appDbContext.SaveChangesAsync();

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
