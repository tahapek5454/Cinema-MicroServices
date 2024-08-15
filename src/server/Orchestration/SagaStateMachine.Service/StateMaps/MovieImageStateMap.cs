
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SagaStateMachine.Service.StateInstances;

namespace SagaStateMachine.Service.StateMaps
{
    public class MovieImageStateMap: SagaClassMap<MovieImageStateInstance>
    {
        protected override void Configure(EntityTypeBuilder<MovieImageStateInstance> entity, ModelBuilder model)
        {
            entity.Property(x => x.FileName).IsRequired();
            entity.Property(x => x.Storage).IsRequired();
            entity.Property(x => x.RelationId).IsRequired();
            entity.Property(x => x.Path).IsRequired();
            entity.Property(x => x.FileId).IsRequired();
        }
    }
}
