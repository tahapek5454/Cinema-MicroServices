using AutoMapper;
using Cinema.Services.SessionAPI.Mapper.SeatProfile;
using Cinema.Services.SessionAPI.Mapper.SeatStatusProfile;
using Cinema.Services.SessionAPI.Mapper.SessionProfile;

namespace Cinema.Services.SessionAPI.Mapper
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

            });

            return config.CreateMapper();
        });

        public static IMapper Mapper { get { return lazy.Value; } }
    }
}
