using AutoMapper;
using Cinema.Services.SessionAPI.Application.Mapper.MovieTheaterProfile;
using Cinema.Services.SessionAPI.Application.Mapper.SeatProfile;
using Cinema.Services.SessionAPI.Application.Mapper.SeatStatusProfile;
using Cinema.Services.SessionAPI.Application.Mapper.SessionProfile;

namespace Cinema.Services.SessionAPI.Application.Mapper
{
    public class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;

                cfg.AddProfile<SeatMapper>();
                cfg.AddProfile<SeatStatusMapper>();
                cfg.AddProfile<SessionMapper>();
                cfg.AddProfile<MovieTheaterMapper>();

            });

            return config.CreateMapper();
        });

        public static IMapper Mapper { get { return lazy.Value; } }
    }
}
