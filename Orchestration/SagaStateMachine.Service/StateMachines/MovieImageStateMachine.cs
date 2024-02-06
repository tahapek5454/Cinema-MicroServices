﻿
using MassTransit;
using SagaStateMachine.Service.StateInstances;
using SharedLibrary.Events.MovieImageEvents;
using SharedLibrary.Messages;
using SharedLibrary.Settings;

namespace SagaStateMachine.Service.StateMachines
{
    public class MovieImageStateMachine: MassTransitStateMachine<MovieImageStateInstance>
    {
        public Event<MovieImageUploadStartedEvent> MovieImageUploadStartedEvent { get; set; }
        public Event<MovieImageReceivedEvent> MovieImageReceivedEvent { get; set; }
        public Event<MovieImageNotReceivedEvent> MovieImageNotReceivedEvent { get; set; }

        public State MovieImageUploaded { get; set; }
        public State MovieImageReceived { get; set; }
        public State MovieImageNotReceived { get; set; }

        public MovieImageStateMachine()
        {
            InstanceState(instance => instance.CurrentState);

            Event(() => MovieImageUploadStartedEvent, (movieImageStateInstance) =>
            {
                movieImageStateInstance.CorrelateBy<string>(database => database.FileName, @event => @event.Message.FileName)
                .SelectId(e => Guid.NewGuid());
            });

            Event(() => MovieImageReceivedEvent, (movieImageStateInstance) =>
            {
                movieImageStateInstance.CorrelateById(@event => @event.Message.CorrelationId);
            });

            Event(() => MovieImageNotReceivedEvent, (movieImageStateInstance) =>
            {
                movieImageStateInstance.CorrelateById(@event => @event.Message.CorrelationId);
            });


            Initially(
                        When(MovieImageUploadStartedEvent)
                        .Then(context =>
                        {
                            context.Instance.Path = context.Data.Path;
                            context.Instance.RelationId = context.Data.RelationId;
                            context.Instance.FileId = context.Data.FileId;
                            context.Instance.FileName = context.Data.FileName;
                            context.Instance.Storage = context.Data.Storage;
                        })
                        .TransitionTo(MovieImageUploaded)
                        .Send(new Uri($"queue:{RabbitMQSettings.Movie_MovieImageUploadedQueue}"), context => new MovieImageUploadedEvent(context.Instance.CorrelationId)
                        {
                            Storage = context.Data.Storage,
                            FileName = context.Data.FileName,
                            Path = context.Data.Path,
                            RelationId = context.Data.RelationId,
                            
                        })
                );



            During(
                    MovieImageUploaded, 
                    When(MovieImageReceivedEvent)
                    .TransitionTo(MovieImageReceived)
                    .Finalize(),
                    When(MovieImageNotReceivedEvent)
                    .TransitionTo(MovieImageNotReceived)
                    .Send(new Uri($"queue:{RabbitMQSettings.File_MovieImageRollbackMessageQueue}"), context => new MovieImageRollbackMessage()
                    {
                        FileName = context.Data.FileName,
                    })
                );

            SetCompletedWhenFinalized();

        }
    }
}
