using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WineTrip.DataModel
{
    public class Model
    {
        [DataMember]
        public ObservableCollection<Trip> Trips { get; set; } = new ObservableCollection<Trip>();
        [DataMember]
        public ObservableCollection<Member> Members { get; set; } = new ObservableCollection<Member>();
        /// <summary>
        ///  don't persist
        /// </summary>
    //    public ObservableCollection<DailyEvents> EventsPerDay { get; set; } = new ObservableCollection<DailyEvents>();
    }
}
