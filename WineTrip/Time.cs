using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WineTrip
{
    [DataContract]
    public class Time
    {
        [DataMember]
        public int day { get; set; } = 0;
        [DataMember]
        public int hour { get; set; }
        [DataMember]
        public int minute { get; set; }

        public int minutes { get { return day * 1440 + hour * 60 + minute; } }

        public Time(int days, int hours, int minutes)
        {
            minute = minutes % 60;
            if(minute < 0)
            {
                hours--;
                minute += 60;
            }
            hours += minutes / 60;
            hour = hours % 24;
            if(hours < 0)
            {
                days--;
                hours += 24;
            }
            days += hour / 24;
            day = days;
        }

        public static Time Create(int day, string timeString)
        {
            int hour;
            int minute;
            string[] parts = timeString.Split(':');
            if (parts.Length != 2) return null;
            if (!int.TryParse(parts[0], out hour)) return null;
            if (hour < 0 || hour > 23) return null;
            if (!int.TryParse(parts[1], out minute)) return null;
            if (minute < 0 || minute > 59) return null;
            return new Time(day, hour, minute);
        }

        public static Time operator +(Time startTime, int minutes)
        {
            return new Time(startTime.day, startTime.hour, startTime.minute + minutes);
        }

        public static Time operator -(Time startTime, int minutes)
        {
            return new Time(startTime.day, startTime.hour, startTime.minute - minutes);
        }

        public string TimeString
        {
            get
            {
                return string.Format("{0:00}:{1:00}", hour, minute);
            }
        }
    }
}
