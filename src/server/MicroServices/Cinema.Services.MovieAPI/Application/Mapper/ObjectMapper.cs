using AutoMapper;
using Cinema.Services.MovieAPI.Application.Mapper.MovieImageProfile;
using Cinema.Services.MovieAPI.Application.Mapper.MovieProfile;

namespace Cinema.Services.MovieAPI.Application.Mapper
{
    public class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;

                cfg.AddProfile<MovieMapper>();
                cfg.AddProfile<MovieImageMapper>();

            });

            return config.CreateMapper();
        });

        public static IMapper Mapper { get { return lazy.Value; } }
    }
}
