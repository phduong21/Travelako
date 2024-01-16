using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FT.Travelako.EventBus.Messages.Events
{
    public class TravelEvent : IntegrationBaseEvent
    {
        public string TourName { get; set; }
        public Guid TravelId { get; set; }
        public Guid UserId { get; set; }
    }
}
