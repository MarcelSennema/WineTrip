using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineTrip.DataModel;

namespace WineTrip
{
    public static class SelectedEvent
    {
        public delegate void handleSelectedEventChange(Event evnt);
        private static Event _selectedEvent = null;
        public static event handleSelectedEventChange SelectedEventChangeHandler;
        public static bool dragging = false;
        public static int dragInitialOffset = 0;
        public static int dragOffset = 0;
        public static Event selectedEvent
        {
            get
            {
                return _selectedEvent;
            }
            set
            {
                _selectedEvent = value;
                SelectedEventChangeHandler.Invoke(_selectedEvent);
            }
        }

    }
}
