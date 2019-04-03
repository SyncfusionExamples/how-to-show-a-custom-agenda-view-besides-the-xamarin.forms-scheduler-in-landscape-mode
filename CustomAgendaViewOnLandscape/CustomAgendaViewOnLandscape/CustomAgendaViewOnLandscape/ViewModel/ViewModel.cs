using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace CustomAgendaViewOnLandscape
{
    public class ViewModel : INotifyPropertyChanged
    {
        private int scheduleRowValue;
        private int scheduleColumnValue;
        private int scheduleRowSpan;
        private int scheduleColumnSpan;
        private int listViewRowValue;
        private int listViewColumnValue;
        public int listViewRowSpan;
        private int listViewColumnSpan;
        private ObservableCollection<Meeting> meetings;
        private ObservableCollection<Meeting> selectedDateMeetings;
        private ObservableCollection<string> subjectCollection;
        private ObservableCollection<Color> colorCollection;
        private string selectedDate;

        public ViewModel()
        {
            Meetings = new ObservableCollection<Meeting>();
            AddAppointmentDetails();
            AddAppointments();
            this.SetGridValue();
        }

        public int ScheduleRowValue
        {
            get
            {
                return scheduleRowValue;
            }
            set
            {
                scheduleRowValue = value;
                RaiseOnPropertyChanged("ScheduleRowValue");
            }
        }

        public int ScheduleColumnValue
        {
            get
            {
                return scheduleColumnValue;
            }
            set
            {
                scheduleColumnValue = value;
                RaiseOnPropertyChanged("ScheduleColumnValue");
            }
        }

        public int ScheduleRowSpan
        {
            get
            {
                return scheduleRowSpan;
            }
            set
            {
                scheduleRowSpan = value;
                RaiseOnPropertyChanged("ScheduleRowSpan");
            }
        }

        public int ScheduleColumnSpan
        {
            get
            {
                return scheduleColumnSpan;
            }
            set
            {
                scheduleColumnSpan = value;
                RaiseOnPropertyChanged("ScheduleColumnSpan");
            }
        }


        public int ListViewRowValue
        {
            get
            {
                return listViewRowValue;
            }
            set
            {
                listViewRowValue = value;
                RaiseOnPropertyChanged("ListViewRowValue");
            }
        }

        public int ListViewColumnValue
        {
            get
            {
                return listViewColumnValue;
            }
            set
            {
                listViewColumnValue = value;
                RaiseOnPropertyChanged("ListViewColumnValue");
            }
        }

        public int ListViewRowSpan
        {
            get
            {
                return listViewRowSpan;
            }
            set
            {
                listViewRowSpan = value;
                RaiseOnPropertyChanged("ListViewRowSpan");
            }
        }


        public int ListViewColumnSpan
        {
            get
            {
                return listViewColumnSpan;
            }
            set
            {
                listViewColumnSpan = value;
                RaiseOnPropertyChanged("ListViewColumnSpan");
            }
        }

        public ObservableCollection<Meeting> Meetings
        {
            get { return meetings; }
            set
            {
                meetings = value;
                RaiseOnPropertyChanged("Meetings");
            }
        }

        public ObservableCollection<Meeting> SelectedDateMeetings
        {
            get { return selectedDateMeetings; }
            set
            {
                selectedDateMeetings = value;
                RaiseOnPropertyChanged("SelectedDateMeetings");
            }
        }

        public string SelectedDate
        {
            get { return selectedDate; }
            set
            {
                selectedDate = value;
                RaiseOnPropertyChanged("SelectedDate");
            }
        }

        //creating color collection
        private void AddAppointmentDetails()
        {
            subjectCollection = new ObservableCollection<string>();
            subjectCollection.Add("General Meeting");
            subjectCollection.Add("Plan Execution");
            subjectCollection.Add("Project Plan");
            subjectCollection.Add("Consulting");
            subjectCollection.Add("Support");
            subjectCollection.Add("Development Meeting");
            subjectCollection.Add("Scrum");
            subjectCollection.Add("Project Completion");
            subjectCollection.Add("Release updates");
            subjectCollection.Add("Performance Check");

            colorCollection = new ObservableCollection<Color>();
            colorCollection.Add(Color.FromHex("#FFA2C139"));
            colorCollection.Add(Color.FromHex("#FFD80073"));
            colorCollection.Add(Color.FromHex("#FF1BA1E2"));
            colorCollection.Add(Color.FromHex("#FFE671B8"));
            colorCollection.Add(Color.FromHex("#FFF09609"));
            colorCollection.Add(Color.FromHex("#FF339933"));
            colorCollection.Add(Color.FromHex("#FF00ABA9"));
            colorCollection.Add(Color.FromHex("#FFE671B8"));
            colorCollection.Add(Color.FromHex("#FF1BA1E2"));
            colorCollection.Add(Color.FromHex("#FFD80073"));
            colorCollection.Add(Color.FromHex("#FFA2C139"));
            colorCollection.Add(Color.FromHex("#FFA2C139"));
            colorCollection.Add(Color.FromHex("#FFD80073"));
            colorCollection.Add(Color.FromHex("#FF339933"));
            colorCollection.Add(Color.FromHex("#FFE671B8"));
            colorCollection.Add(Color.FromHex("#FF00ABA9"));
        }

        private void AddAppointments()
        {
            var today = DateTime.Now.Date;
            var random = new Random();
            for (int month = -1; month <= 1; month++)
            {
                for (int i = -3; i <= 3; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        var appointment = new Meeting();
                        appointment.EventName = subjectCollection[random.Next(3)];
                        appointment.From = today.AddMonths(month).AddDays(random.Next(1, 28)).AddHours(random.Next(9, 18));
                        appointment.To = appointment.From.AddHours(2);
                        appointment.color = colorCollection[random.Next(11)];
                        appointment.IsAllDay = false;
                        this.Meetings.Add(appointment);
                    }
                }
            }
        }

        private void SetGridValue()
        {
            this.scheduleRowValue = 0;
            this.listViewRowValue = 1;
            this.scheduleColumnValue = 0;
            this.listViewColumnValue = 0;
            this.scheduleRowSpan = 1;
            this.listViewRowSpan = 1;
            this.scheduleColumnSpan = 2;
            this.listViewColumnSpan = 2;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void RaiseOnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
