using MassTransit;
using SagaStateMachine.Host.StateInstances;
using SharedLibrary.Events.MovieChangeEvents;
using SharedLibrary.Events.MovieChangeEvents.AddMovieEvents;
using SharedLibrary.Helpers;
using SharedLibrary.Messages;
using SharedLibrary.Settings;

namespace SagaStateMachine.Host.StateMachines
{
    public class MovieChangeStateMachine: MassTransitStateMachine<MovieChangeStateInstance>
    {
     
        public Event<MovieChangeStartedEvent> MovieChangeStartedEvent { get; set; }
        public Event<MovieChangeReceivedFromCategoryEvent> MovieChangeReceivedFromCategoryEvent { get; set; }
        public Event<MovieChangeNotReceivedFromCategoryEvent> MovieChangeNotReceivedFromCategoryEvent { get; set; }
        public Event<MovieChangeReceivedFromFileEvent> MovieChangeReceivedFromFileEvent { get; set; }

        public State MovieChanged { get; set; }
        public State MovieChangeReservedFromCategory { get; set; }
        public State MovieChangeNotReservedFromCategory { get; set; }
        public State MovieChangeReservedFromFile { get; set; }
    


        public MovieChangeStateMachine()
        {
            InstanceState(x => x.CurrentState);

      
            Event(() => MovieChangeStartedEvent, (instance) =>
            {
                instance.CorrelateBy(database => database.MovieIds, @event => @event.Message.MovieIds)
                .SelectId(e => Guid.NewGuid());
            });

            Event(() => MovieChangeReceivedFromCategoryEvent, (instance) =>
            {
                instance.CorrelateById(@event => @event.Message.CorrelationId);
            });

            Event(() => MovieChangeNotReceivedFromCategoryEvent, (instance) =>
            {
                instance.CorrelateById(@event => @event.Message.CorrelationId);
            });

            Event(() => MovieChangeReceivedFromFileEvent, (instance) =>
            {
                instance.CorrelateById(@event => @event.Message.CorrelationId);
            });
    

        
            Initially(
                When(MovieChangeStartedEvent)
                .Then(context =>
                {
                    context.Instance.CategoryIds = context.Message.CategoryIds;
                    context.Instance.MovieIds = context.Message.MovieIds;
                    context.Instance.CreatedTime = context.Message.CreatedTime;
                    context.Instance.CrudStatus = context.Message.CrudStatus;

                })
                .TransitionTo(MovieChanged)
                .Send(new Uri($"queue:{RabbitMQSettings.Category_MovieChangeQueue}"), context => new MovieChangeFillCategoryEvent(context.Instance.CorrelationId)
                {
                    CategoryIds = StringListConvert.ConvertToList<int>(context.Message.CategoryIds),  
                    MovieIds = StringListConvert.ConvertToList<int>(context.Message.MovieIds),
                    CrudStatus = context.Message.CrudStatus,
                    UpdateResults = context.Message.UpdateResults,
                })
                );

            During(
                MovieChanged,
                When(MovieChangeReceivedFromCategoryEvent)
                .TransitionTo(MovieChangeReservedFromCategory)
                .Send(new Uri($"queue:{RabbitMQSettings.File_MovieChangeQueue}"), context => new MovieChangeFillMovieImageEvent(context.Instance.CorrelationId)
                {
                    MovieIds = context.Message.MovieIds,
                    CrudStatus = context.Message.CrudStatus,
                    
                }),
                When(MovieChangeNotReceivedFromCategoryEvent)
                .TransitionTo(MovieChangeNotReservedFromCategory)
                .Send(new Uri($"queue:{RabbitMQSettings.Movie_MovieChangeRollBackMessageQueue}"), context => new MovieRollBackMessage()
                {
                    MovieIds = context.Message.MovieIds,
                    CrudStatus = context.Message.CrudStatus, 
                    UpdateResults = context.Message.UpdateResults
                })
                );

            During(
                MovieChangeReservedFromCategory,
                When(MovieChangeReceivedFromFileEvent)
                .TransitionTo(MovieChangeReservedFromFile)
                .Finalize()
                );

            SetCompletedWhenFinalized();
        }
    }
}
