using AutoMapper;
using Cinema.Services.CategoryAPI.Mapper.CategoryProfile;


namespace Cinema.Services.CategoryAPI.Mapper
{
    public class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;

                cfg.AddProfile<CategoryMapper>();

            });

            return config.CreateMapper();
        });

        public static IMapper Mapper { get { return lazy.Value; } }
    }
}
