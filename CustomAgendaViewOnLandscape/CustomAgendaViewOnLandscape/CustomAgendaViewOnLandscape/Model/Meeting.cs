using System;
using Xamarin.Forms;

namespace CustomAgendaViewOnLandscape
{
    public class Meeting
    {
        public string EventName { get; set; }
        public string Organizer { get; set; }
        public string ContactID { get; set; }
        public int Capacity { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Color color { get; set; }
        public double MinimumHeight { get; set; }
        public bool IsAllDay { get; set; }
    }
}

