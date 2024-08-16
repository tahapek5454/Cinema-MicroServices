using MassTransit;
using SagaStateMachine.Host.StateInstances;
using SharedLibrary.Events.ReservationEvents;
using SharedLibrary.Messages;
using SharedLibrary.Settings;

namespace SagaStateMachine.Host.StateMachines
{
    public class ReservationStateMachine : MassTransitStateMachine<ReservationStateInstance>
    {
        public Event<ReservedStartedEvent> ReservedStartedEvent { get; set; }
        public Event<ReserveReceivedEvent> ReserveReceivedEvent { get; set; }
        public Event<ReserveFailedEvent> ReserveFailedEvent { get; set; }

        public State Reserved { get; set; }
        public State ReserveReceived { get; set; }
        public State ReserveFailed { get; set; }


        public ReservationStateMachine()
        {
            InstanceState(instance => instance.CurrentState);

            Event(() => ReservedStartedEvent, (instance) =>
            {
                instance.CorrelateBy<int>(database => database.ReservationId, @event => @event.Message.ReservationId)
                .SelectId(e => Guid.NewGuid());
            });

            Event(() => ReserveReceivedEvent, (instance) =>
            {
                instance.CorrelateById(@event => @event.Message.CorrelationId);
            });

            Event(() => ReserveFailedEvent, (instance) =>
            {
                instance.CorrelateById(@event => @event.Message.CorrelationId);
            });


            Initially(
                    When(ReservedStartedEvent)
                    .Then(context =>
                    {
                        context.Instance.SeatIds = context.Message.SeatIds;
                        context.Instance.SessionId = context.Message.SessionId;
                        context.Instance.UserId = context.Message.UserId;
                        context.Instance.ReservationId = context.Message.ReservationId;
                        context.Instance.MovieTheaterId = context.Message.MovieTheaterId;
                        context.Instance.Price = context.Message.Price;
                        context.Instance.ReservationCreatedDate = context.Message.ReservationCreatedDate;
                    })
                    .TransitionTo(Reserved)
                    .Send(new Uri($"queue:{RabbitMQSettings.Session_ReservedQueue}"), context => new ReservedEvent(context.Instance.CorrelationId)
                    {
                        MovieTheaterId = context.Instance.MovieTheaterId,
                        Price = context.Instance.Price,
                        ReservationCreatedDate = context.Instance.ReservationCreatedDate,
                        ReservationId = context.Instance.ReservationId,
                        SeatIds = context.Instance.SeatIds,
                        SessionId = context.Instance.SessionId,
                        UserId = context.Instance.UserId
                    })

                );



            During(
                    Reserved,
                    When(ReserveReceivedEvent)
                    .TransitionTo(ReserveReceived)
                    .Finalize()
                    ,
                    When(ReserveFailedEvent)
                    .TransitionTo(ReserveFailed)
                    .Send(new Uri($"queue:{RabbitMQSettings.Reservation_ReservationRollbackMessageQueue}"), context => new ReservationRollbackMessage()
                    {
                        ReservationId = context.Instance.ReservationId,
                    })
                );

            SetCompletedWhenFinalized();

        }
    }
}
