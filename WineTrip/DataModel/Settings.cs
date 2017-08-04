using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WineTrip.DataModel
{
    [DataContract]
    public class Settings
    {
        [DataMember]
        public int startHour { get; set; } = 7;
        [DataMember]
        public int endHour { get; set; } = 20;
        [DataMember]
        public int resolution { get; set; } = 15; // schedule accuracy is 15 minutes

    }
}
