using SharedLibrary.Models.Entities;

namespace Cinema.Services.BranchAPI.Domain.Entities
{
    public class District : BaseEntity
    {
        public string Name { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public List<Branch> Branches { get; set; }
    }
}
