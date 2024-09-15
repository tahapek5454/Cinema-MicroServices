using MediatR;

namespace Cinema.Services.BranchAPI.Application.Queries.Cities.GetCityById
{
    public class GetCityByIdRequest: IRequest<GetCityByIdResponse>
    {
        public int Id { get; set; }
    }
}
