using AutoMapper;
using Cinema.Services.BranchAPI.Application.Mapper.BranchProfile;
using Cinema.Services.BranchAPI.Application.Mapper.CitiyProfile;
using Cinema.Services.BranchAPI.Application.Mapper.DistrictProfile;

namespace Cinema.Services.BranchAPI.Application.Mapper
{
    public class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;

                cfg.AddProfile<BranchMapper>();
                cfg.AddProfile<DistrictMapper>();
                cfg.AddProfile<CityMapper>();


            });

            return config.CreateMapper();
        });

        public static IMapper Mapper { get { return lazy.Value; } }
    }
}
