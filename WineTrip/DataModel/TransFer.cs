using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WineTrip.DataModel
{
    [DataContract(IsReference = true)]
    public class Transfer
    {
        public Transfer(Event startEvent, Event endEvent)
        {
            this.startEvent = startEvent;
            this.endEvent = endEvent;
        }

        [DataMember]
        public Event startEvent { get; set; }
        [DataMember]
        public Event endEvent { get; set; }
        [DataMember]
        public int duration { get; set; } = 0;
        [DataMember]
        public string distance { get; set; }
        [DataMember]
        public Bitmap map { get; set; }

        public string metrics {  get { return $"{duration} min {distance}"; } }
    }
}
