
using MassTransit.EntityFrameworkCoreIntegration;
using Microsoft.EntityFrameworkCore;
using SagaStateMachine.Host.StateMaps;

namespace SagaStateMachine.Host.StateDbContexts
{
    public class MovieAppStateDbContext : SagaDbContext
    {
        public MovieAppStateDbContext(DbContextOptions options) : base(options) { }
        protected override IEnumerable<ISagaClassMap> Configurations
        {
            get
            {
                yield return new MovieImageStateMap();
                yield return new ReservationStateMap();
                yield return new MovieChangeStateMap();
                yield return new CategoryChangeStateMap();
            }
        }
    }
}
