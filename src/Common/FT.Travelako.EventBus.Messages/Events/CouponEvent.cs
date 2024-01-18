using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FT.Travelako.EventBus.Messages.Events
{
    public class CouponEvent : IntegrationBaseEvent
    {
        public string UserId { get; set; }
        public string BusinessId { get; set; }
    }
}
