using MediatR;

namespace Cinema.Services.BranchAPI.Application.Queries.Cities.GetCities
{
    public class GetCitiesRequest: IRequest<List<GetCitiesResponse>>
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
    }
}
