using Cinema.Services.MovieAPI.Application.Mapper;
using Cinema.Services.MovieAPI.Application.Services.Abstract;
using Cinema.Services.MovieAPI.Infrastructure.Services.Concrete;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Events.MovieChangeEvents;
using SharedLibrary.Models.Dtos;
using SharedLibrary.Models.SharedModels.Movies;
using SharedLibrary.Repositories.SharedModelRepositories.Abstract;
using SharedLibrary.Settings;

namespace Cinema.Services.MovieAPI.Application.Commands.Movies.UpdateMovie
{
    public class UpdateMovieRequestHandler(IMovieService _movieService, MovieUnitOfWork _movieUnitOfWork, ISendEndpointProvider _sendEndpointProvider, ISharedMovieRepository _sharedMovieRepository) : IRequestHandler<UpdateMovieRequest, UpdateMovieResponse>
    {
        public async Task<UpdateMovieResponse> Handle(UpdateMovieRequest request, CancellationToken cancellationToken)
        {
            var movie = await _movieService.Table.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (movie is null) throw new Exception("Güncellenecek Film Bulunamadı.");


            var updateResults = _movieService.UpdateAdvance(movie, request);

            if (!updateResults.Any())
            {
                return new UpdateMovieResponse()
                {
                    Result = ResponseDto<BlankDto>.Sucess(200)
                };
            }

            await _movieUnitOfWork.SaveChangesAsync();

            var sharedMovie = ObjectMapper.Mapper.Map<MovieSharedVM>(movie);
            var oldMovieShared = await _sharedMovieRepository.GetByIdAsync(sharedMovie.Id);
            await _sharedMovieRepository.UpdateAsync(sharedMovie.Id, sharedMovie);

            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint
                (new Uri($"queue:{RabbitMQSettings.MovieChangeStateMachineQueue}"));

            await sendEndpoint.Send(new MovieChangeStartedEvent()
            {
                CategoryIds = movie.CategoryId.ToString(),
                CreatedTime = DateTime.Now,
                CrudStatus = SharedLibrary.Enums.CRUDStatusEnum.Update,
                MovieIds = movie.Id.ToString(),
                UpdateResults = updateResults,
                OldMovieValues = new() { oldMovieShared } 
            });



            return new UpdateMovieResponse()
            {
                Result = ResponseDto<BlankDto>.Sucess(200)
            };

        }
    }
}
