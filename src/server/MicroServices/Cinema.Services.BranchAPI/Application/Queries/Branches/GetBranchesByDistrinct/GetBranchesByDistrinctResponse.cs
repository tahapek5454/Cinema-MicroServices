namespace Cinema.Services.BranchAPI.Application.Queries.Branches.GetBranchesByDistrinct
{
    public class GetBranchesByDistrinctResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int DistrictId { get; set; }
    }
}
