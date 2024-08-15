using SharedLibrary.Models.Entities;

namespace Cinema.Services.BranchAPI.Models.Entities
{
    public class Branch: BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string? Address_EN { get; set; }
        public string Description { get; set; }
        public string? Description_EN { get; set; }
        public int DistrictId { get; set; }
        public District District { get; set; }

    }
}
