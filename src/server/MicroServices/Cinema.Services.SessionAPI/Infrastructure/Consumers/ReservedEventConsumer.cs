using Cinema.Services.SessionAPI.Application.Services.Abstract;
using Cinema.Services.SessionAPI.Domain.Entities;
using MassTransit;
using MassTransit.Transports;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Enums;
using SharedLibrary.Events.ReservationEvents;
using SharedLibrary.Settings;

namespace Cinema.Services.SessionAPI.Infrastructure.Consumers
{
    public class ReservedEventConsumer(ISeatSessionStatusService _seatSessionStatusService) : IConsumer<ReservedEvent>
    {

        private readonly ISendEndpoint _sendEndpoint;

        public ReservedEventConsumer(ISendEndpointProvider _sendEndpointProvider, ISeatSessionStatusService _seatSessionStatusService) : this(_seatSessionStatusService)
        {
            _sendEndpoint = _sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{RabbitMQSettings.ReservationStateMachineQueue}")).Result;

        }

        public async Task Consume(ConsumeContext<ReservedEvent> context)
        {


            if (context.Message.SeatIds is not null)
            {

                SeatSessionStatus originalSeatSessionStatus = new()
                {
                    ReservedStatus = ReservedStatusEnum.Reserved,
                    SessionId = context.Message.SessionId,
                };

                var ids = context.Message.SeatIds.Split(',').Select(int.Parse).ToList();
                // maybe throw exception you should handle to reservation 


                var isValid = CheckSeatIsReadyForReserve(ids, context.Message.SessionId);

                if (!isValid)
                {
                    await FailPublish(context.Message, "Seçili koltuklar rezervasyon için uygun değildir.");

                    return;
                }


                List<SeatSessionStatus> response = new();

                foreach (var seatId in ids)
                {

                    var clone = (SeatSessionStatus)originalSeatSessionStatus.Clone();

                    if (clone is null)
                        continue;

                    clone.SeatId = seatId;

                    response.Add(clone);
                }

                if (response.Any())
                {
                    _seatSessionStatusService.Table.UpdateRange(response);
                    await _seatSessionStatusService.SaveChangesAsync();


                    await SuccessPublish(context.Message);

                    return;
                }

            }

            await FailPublish(context.Message, "Seçili koltuk bulunamadı.");

            return;

        }

        private bool CheckSeatIsReadyForReserve(List<int> seatIds, int sessionId)
        {
            var datas = _seatSessionStatusService.Table.AsNoTracking().Where(x => x.SessionId == sessionId);

            var filteredDatas = datas.Where(x => seatIds.Contains(x.SeatId)).ToList();

            if (seatIds.Count != filteredDatas.Count)
                return false;

            return filteredDatas is not null ? filteredDatas.TrueForAll(x => x.ReservedStatus == ReservedStatusEnum.Pending) : false;
        }

        private async Task SuccessPublish(ReservedEvent @event)
        {
            await _sendEndpoint.Send<ReserveReceivedEvent>(new(@event.CorrelationId)
            {
                MovieTheaterId = @event.MovieTheaterId,
                UserId = @event.UserId,
                Price = @event.Price,
                ReservationCreatedDate = @event.ReservationCreatedDate,
                ReservationId = @event.ReservationId,
                SeatIds = @event.SeatIds,
                SessionId = @event.SessionId
            });
        }

        private async Task FailPublish(ReservedEvent @event, string errorMessage)
        {
            await _sendEndpoint.Send<ReserveFailedEvent>(new(@event.CorrelationId)
            {
                ReservationId = @event.ReservationId,
                ErrorMessage = errorMessage
            });
        }
    }
}
