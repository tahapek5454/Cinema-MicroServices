using Cinema.Services.BranchAPI.Application.Repositories;
using Cinema.Services.BranchAPI.Application.Services.Abstract;
using Cinema.Services.BranchAPI.Domain.Entities;
using SharedLibrary.Services;

namespace Cinema.Services.BranchAPI.Infrastructure.Services.Concrete
{
    public class DistrictService : BaseEntityService<District>, IDistrictService
    {
        private readonly IDistrictRepository _districtRepository;
        public DistrictService(IHttpClientFactory _httpClientFactory, IDistrictRepository repository) : base(_httpClientFactory, repository)
        {
            _districtRepository = repository;
        }
    }
}
