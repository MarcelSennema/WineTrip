using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WineTrip.DataModel
{
    [DataContract]
    public class Payment
    {
        [DataMember]
        public Member member { get; set; }

        [DataMember]
        public decimal amount { get; set; }
    }
}
