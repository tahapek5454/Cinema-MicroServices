using Cinema.Services.BranchAPI.Application.Repositories;
using Cinema.Services.BranchAPI.Application.Services.Abstract;
using Cinema.Services.BranchAPI.Domain.Entities;
using SharedLibrary.Services;

namespace Cinema.Services.BranchAPI.Infrastructure.Services.Concrete
{
    public class BranchService : BaseEntityService<Branch>, IBranchService
    {
        private readonly IBranchRepository _repository;
        public BranchService(IHttpClientFactory _httpClientFactory, IBranchRepository repository) : base(_httpClientFactory, repository)
        {
            _repository = repository;
        }
    }
}
