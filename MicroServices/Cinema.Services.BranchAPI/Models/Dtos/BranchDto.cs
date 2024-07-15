using Cinema.Services.BranchAPI.Models.Entities;

namespace Cinema.Services.BranchAPI.Models.Dtos
{
    public class BranchDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int DistrictId { get; set; }
    }
}
