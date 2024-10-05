using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SagaStateMachine.Host.StateInstances;

namespace SagaStateMachine.Host.StateMaps
{
    public class MovieChangeStateMap:SagaClassMap<MovieChangeStateInstance>
    {
        protected override void Configure(EntityTypeBuilder<MovieChangeStateInstance> entity, ModelBuilder model)
        {
            entity.Property(x => x.MovieIds).IsRequired();
            entity.Property(x => x.CategoryIds).IsRequired();
            entity.Property(x => x.CreatedTime).IsRequired();
            entity.Property(x => x.CrudStatus).IsRequired();

            base.Configure(entity, model);
        }
    }
}
