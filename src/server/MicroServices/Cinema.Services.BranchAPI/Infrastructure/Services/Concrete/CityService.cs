using Cinema.Services.BranchAPI.Application.Repositories;
using Cinema.Services.BranchAPI.Application.Services.Abstract;
using Cinema.Services.BranchAPI.Domain.Entities;
using SharedLibrary.Services;

namespace Cinema.Services.BranchAPI.Infrastructure.Services.Concrete
{
    public class CityService : BaseEntityService<City>, ICityService
    {
        private readonly ICityRepository _cityRepository;
        public CityService(IHttpClientFactory _httpClientFactory, ICityRepository repository) : base(_httpClientFactory, repository)
        {
            _cityRepository = repository;
        }
    }
}
