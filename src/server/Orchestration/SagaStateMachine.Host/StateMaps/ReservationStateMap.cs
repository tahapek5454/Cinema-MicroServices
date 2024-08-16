using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SagaStateMachine.Host.StateInstances;

namespace SagaStateMachine.Host.StateMaps
{
    public class ReservationStateMap : SagaClassMap<ReservationStateInstance>
    {
        protected override void Configure(EntityTypeBuilder<ReservationStateInstance> entity, ModelBuilder model)
        {
            entity.Property(x => x.ReservationId).IsRequired();
            entity.Property(x => x.Price).IsRequired();
            entity.Property(x => x.MovieTheaterId).IsRequired();
            entity.Property(x => x.UserId).IsRequired();
            entity.Property(x => x.SessionId).IsRequired();
        }
    }
}
