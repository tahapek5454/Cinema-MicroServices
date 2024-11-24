﻿using Cinema.Services.BranchAPI.Application.Dtos;

namespace Cinema.Services.BranchAPI.Application.Queries.Branches.GetAllBranches
{
    public class GetAllBranchesResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int DistrictId { get; set; }
        public DistrictDto District { get; set; }
    }
}
