using Cinema.Services.MovieAPI.Application.Mapper;
using Cinema.Services.MovieAPI.Application.Services.Abstract;
using Cinema.Services.MovieAPI.Domain.Entities;
using Cinema.Services.MovieAPI.Infrastructure.Services.Concrete;
using MassTransit;
using MediatR;
using SharedLibrary.Events.MovieChangeEvents;
using SharedLibrary.Models.Dtos;
using SharedLibrary.Models.SharedModels.Movies;
using SharedLibrary.Repositories.SharedModelRepositories.Abstract;
using SharedLibrary.Settings;

namespace Cinema.Services.MovieAPI.Application.Commands.Movies.AddMovie
{
    public class AddMovieRequestHandler(IMovieService _movieService, MovieUnitOfWork _movieUnitOfWork, ISendEndpointProvider _sendEndpointProvider, ISharedMovieRepository _sharedMovieRepository) : IRequestHandler<AddMovieRequest, AddMovieResponse>
    {
        public async Task<AddMovieResponse> Handle(AddMovieRequest request, CancellationToken cancellationToken)
        {
            var newMovie = ObjectMapper.Mapper.Map<Movie>(request);

            await _movieService.Table.AddAsync(newMovie);

            await _movieUnitOfWork.SaveChangesAsync();

            var sahredMovie = ObjectMapper.Mapper.Map<MovieSharedVM>(newMovie);
            await _sharedMovieRepository.AddAsync(sahredMovie);

            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint
                (new Uri($"queue:{RabbitMQSettings.MovieChangeStateMachineQueue}"));

       
            await sendEndpoint.Send(new MovieChangeStartedEvent()  
            {
                CategoryIds = newMovie.CategoryId.ToString(),
                CreatedTime = DateTime.Now,
                CrudStatus = SharedLibrary.Enums.CRUDStatusEnum.Insert,
                MovieIds = newMovie.Id.ToString(),
            });

            return new()
            {
                Result = ResponseDto<int>.Sucess(newMovie.Id, 201)
            };
        }
    }
}
