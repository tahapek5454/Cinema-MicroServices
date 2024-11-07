using MassTransit;
using SagaStateMachine.Host.StateInstances;
using SharedLibrary.Events.CategoryChangeEvent;
using SharedLibrary.Events.MovieChangeEvents;
using SharedLibrary.Events.MovieChangeEvents.AddMovieEvents;
using SharedLibrary.Helpers;
using SharedLibrary.Messages;
using SharedLibrary.Settings;

namespace SagaStateMachine.Host.StateMachines
{
    public class CategoryChangeStateMachine : MassTransitStateMachine<CategoryChangedStateInstance>
    {
        public Event<CategoryChangeStartedEvent> CategoryChangeStartedEvent { get; set; }
        public Event<CategoryChangeReceivedFromMovieEvent> CategoryChangeReceivedFromMovieEvent { get; set; }

        public State CategoryChange { get; set; }
        public State CategoryChangeReceivedFromMovie { get; set; }

        public CategoryChangeStateMachine()
        {
            InstanceState(x => x.CurrentState);

            Event(() => CategoryChangeStartedEvent, (instance) =>
            {
                instance.CorrelateBy<int>(database => database.CategoryId, @event => @event.Message.CategoryId)
                .SelectId(e => Guid.NewGuid());
            });

            Event(() => CategoryChangeReceivedFromMovieEvent, (instance) =>
            {
                instance.CorrelateById(@event => @event.Message.CorrelationId);
            });

            Initially(
                When(CategoryChangeStartedEvent)
                    .Then(context =>
                    {
                        context.Instance.CategoryId = context.Message.CategoryId;
                        context.Instance.CreatedTime = context.Message.CreatedTime;
                    })
                    .TransitionTo(CategoryChange)
                    .Send(new Uri($"queue:{RabbitMQSettings.Movie_CategoryChangeQueue}"), context => new CategoryChangeFillMovieEvent(context.Instance.CorrelationId)
                    {
                        CategoryId = context.Message.CategoryId,
                        CategorySharedVM = context.Message.CategorySharedVM
                    })
                );

            During(
                CategoryChange,
                When(CategoryChangeReceivedFromMovieEvent)
                    .TransitionTo(CategoryChangeReceivedFromMovie)
                    .Finalize()
                );

            SetCompletedWhenFinalized();
        }
    }
}
