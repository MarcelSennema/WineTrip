using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WineTrip.DataModel
{
    [DataContract]
    public class Bottle
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public int vintage { get; set; }
        [DataMember]
        public decimal volume { get; set; } = 0.75M;
        [DataMember]
        public decimal price { get; set; }
        [DataMember]
        public string notitie { get; set; }
        [DataMember]
        public ObservableCollection<Order> orders { get; set; } = new ObservableCollection<Order>();

        public int TotalOrderCount
        {
            get
            {
                return orders.Sum(x => x.count);
            }
        }

        public decimal TotalOrderPrice
        {
            get
            {
                return orders.Sum(x => x.count) * price;
            }
        }


    }
}
