using MassTransit;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SagaStateMachine.Host.StateInstances;

namespace SagaStateMachine.Host.StateMaps
{
    public class CategoryChangeStateMap : SagaClassMap<CategoryChangedStateInstance>
    {
        protected override void Configure(EntityTypeBuilder<CategoryChangedStateInstance> entity, ModelBuilder model)
        {
            entity.Property(x => x.CategoryId).IsRequired();
            entity.Property(x => x.CreatedTime).IsRequired();

            base.Configure(entity, model);
        }
    }
}
