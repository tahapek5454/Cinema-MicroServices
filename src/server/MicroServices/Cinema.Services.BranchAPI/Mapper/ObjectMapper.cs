using AutoMapper;
using Cinema.Services.BranchAPI.Mapper.BranchProfile;
using Cinema.Services.BranchAPI.Mapper.CitiyProfile;
using Cinema.Services.BranchAPI.Mapper.DistrictProfile;


namespace Cinema.Services.BranchAPI.Mapper
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
