using MassTransit;
using SharedLibrary.Models.SharedModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Events.CategoryChangeEvent
{
    public class CategoryChangeReceivedFromMovieEvent : CorrelatedBy<Guid>
    {
        public Guid CorrelationId { get; }

        public CategoryChangeReceivedFromMovieEvent(Guid correlationId)
        {
            CorrelationId = correlationId;
        }

        public int CategoryId { get; set; }
    }
}
