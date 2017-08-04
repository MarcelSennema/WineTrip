using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WineTrip.DataModel
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public int count { get; set; }
        [DataMember]
        public Member member { get; set; }
    }
}
