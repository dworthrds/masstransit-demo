using System;
using Contract;

namespace PrenoteService
{
    public class PrenoteDeleted : IPrenoteDeleted
    {
        public Guid CorrelationId { get; set; }
        public IPrenote Prenote { get; set; }
        public DateTime When { get; set; }
    }
}