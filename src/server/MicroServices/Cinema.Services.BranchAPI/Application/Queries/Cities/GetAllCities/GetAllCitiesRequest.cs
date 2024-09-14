using MediatR;

namespace Cinema.Services.BranchAPI.Application.Queries.Cities.GetAllCities
{
    public class GetAllCitiesRequest: IRequest<List<GetAllCitiesResponse>>
    {
    }
}
