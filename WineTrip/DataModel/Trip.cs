using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WineTrip.DataModel
{
    [DataContract(IsReference = true)]
    public class Trip // we only have one trip at the time!
    {
        [DataMember]
        public string region { get; set; }
        [DataMember]
        public DateTime startDate { get; set; } = DateTime.Now;
        [DataMember]
        public int numberOfDays { get; set; } = 5;
        [DataMember]
        public Settings settings { get; set; } = new Settings();
        [DataMember]
        public ObservableCollection<Event> events { get; set; } = new ObservableCollection<Event>();
        [DataMember]
        public ObservableCollection<Member> members { get; set; } = new ObservableCollection<Member>();
        [DataMember]
        public ObservableCollection<Transfer> transfers { get; set; } = new ObservableCollection<Transfer>();

        public Event GetPreviousPlannedEvent(Time time)
        {
            return events.Where(x => x.GPSLocation != null && x.startMinute < time.minutes).OrderByDescending(x => x.startMinute).FirstOrDefault();
        }

        public Event GetNextPlannedEvent(Time time)
        {
            return events.Where(x => x.GPSLocation != null && x.startMinute > time.minutes).OrderBy(x => x.startMinute).FirstOrDefault();
        }

        public Transfer GetTransferFromPrevious(Event evnt)
        {
            Event previousEvent = GetPreviousPlannedEvent(evnt.start);
            return transfers?.Where(x => x.startEvent == previousEvent && x.endEvent == evnt).FirstOrDefault();
        }

        public Transfer GetTransferToNext(Event evnt)
        {
            Event nextEvent = GetNextPlannedEvent(evnt.start);
            return transfers?.Where(x => x.startEvent == evnt && x.endEvent == nextEvent).FirstOrDefault();
        }

        public void CalculateTransfers()
        {
            var dummy = events.Where(x => x.GPSLocation != null).OrderBy(x => x.start.minutes).Aggregate((x, y) => AddTransfer(x, y));
        }

        private Event AddTransfer(Event startEvent, Event endEvent)
        {
            if (transfers == null)
                transfers = new ObservableCollection<Transfer>();
            if(transfers.Where(x => x.startEvent == startEvent && x.endEvent == endEvent).FirstOrDefault() == null)
            {
                Transfer transfer = new Transfer(startEvent, endEvent);
                GoogleMaps.GetTransferMap(transfer);
                GoogleMaps.GetTimeAndDistance(transfer);
                transfers.Add(transfer);
            }
            return endEvent;
        }
    }
}
