using MassTransit;
using SharedLibrary.Models.SharedModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Events.CategoryChangeEvent
{
    public class CategoryChangeFillMovieEvent : CorrelatedBy<Guid>
    {
        public Guid CorrelationId { get; }

        public CategoryChangeFillMovieEvent(Guid correlationId)
        {
            CorrelationId = correlationId;
        }

        public int CategoryId { get; set; }
        public CategorySharedVM CategorySharedVM { get; set; }
    }
}
