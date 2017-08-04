using WineTrip;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WineTrip.DataModel
{
    [DataContract(IsReference = true)]
    public class Event : Object
    {
        public Event(Trip trip, Time start)
        {
            this.trip = trip;
            this.start = start;
            if (trip != null)
                trip.events.Add(this);

        }

        [DataMember]
        public Trip trip { get; set; }
        [DataMember]
        public Time start { get; set; }
        public Time end { get { return start + duration; } }
        [DataMember]
        public int duration { get; set; } = 90; // standard is 1,5 hrs
        [DataMember]
        public string GPSLocation { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string address { get; set; }
        [DataMember]
        public string eMail { get; set; }
        [DataMember]
        public string webSite { get; set; }
        [DataMember]
        public string locationStatus { get; set; } = "Not verified";
        [DataMember]
        public Bitmap map { get; set; } 
        [DataMember]
        public ObservableCollection<Bottle> bottles { get; set; } = new ObservableCollection<Bottle>();

        public int day { get { return start.day; } set { start.day = (byte)value; } }

        public Transfer transferFrom { get { return trip.GetTransferFromPrevious(this); } }
        public Transfer transferTo { get { return trip.GetTransferToNext(this); } }

        // for binding the time class to a text box
        public string startString { get { return start.ToString(); } set { start = Time.Create(day, value); } }

        public int startMinute {  get { return start.minutes; } }
        public int endMinute { get { return end.minutes; } }
        public Rectangle drawingRect = new Rectangle(); // the rectangle that the event was most recently drawn in
        public List<Event> overlappingEventCluster = null;

        public bool Overlaps(Event evnt)
        {
            return !(evnt.startMinute > endMinute || evnt.endMinute < startMinute); //(endMinute >= evnt.startMinute || startMinute <= evnt.endMinute);
        }

        public Event ShallowCopy()
        {
            return (Event) MemberwiseClone();
        }
    }
}
