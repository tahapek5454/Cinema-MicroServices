using Cinema.Services.RezervationAPI.Application.Services.Abstract;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Events.ReservationEvents;
using SharedLibrary.Messages;

namespace Cinema.Services.RezervationAPI.Infrastructure.Consumers
{
    public class ReservationRollbackConsumer(IReservationService _reservationService) : IConsumer<ReservationRollbackMessage>, IConsumer<Fault<ReservedEvent>>
    {
        public async Task Consume(ConsumeContext<ReservationRollbackMessage> context)
        {
            await RollBackReservation(context.Message.ReservationId);

            // Todo: prebook koltuklar avaliable a cekilmek icin event firlatilabilir.
            // ekstradan olasi hata durumlarinda arka planda 5 dk sure tutulup prebook koltuklar avaliable'a cekilmeli
        }

        public async Task Consume(ConsumeContext<Fault<ReservedEvent>> context)
        {
            await RollBackReservation(context.Message.Message.ReservationId);

            // Todo: prebook koltuklar avaliable a cekilmek icin event firlatilabilir.
            // ekstradan olasi hata durumlarinda arka planda 5 dk sure tutulup prebook koltuklar avaliable'a cekilmeli
        }

        private async Task RollBackReservation(int reservationId)
        {
            var r = await _reservationService.Table.FirstOrDefaultAsync(x => x.Id == reservationId);

            if (r != null)
            {
                _reservationService.Table.Remove(r);
                await _reservationService.SaveChangesAsync();
            }

        }
    }
}
