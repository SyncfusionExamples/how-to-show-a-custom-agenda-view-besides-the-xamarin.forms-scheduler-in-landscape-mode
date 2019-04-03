using System;
using System.Collections.ObjectModel;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;

namespace CustomAgendaViewOnLandscape
{
    public class ContentPageBehavior: Behavior<ContentPage>
    {
        private Grid gridView;
        private Grid listView;
        private SfSchedule schedule;
        public ContentPageBehavior()
        {

        }

        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            schedule = bindable.FindByName<SfSchedule>("schedule");
            listView = bindable.FindByName<Grid>("listview");
            gridView = bindable.FindByName<Grid>("gridView");

            if (Device.RuntimePlatform == "UWP")
            {
                Grid.SetRowSpan(schedule, 2);
            }
            schedule.SelectedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            schedule.CellTapped += Schedule_CellTapped;
            schedule.SizeChanged += Schedule_SizeChanged;
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            schedule.CellTapped -= Schedule_CellTapped;
            schedule = null;
        }

        void Schedule_CellTapped(object sender, CellTappedEventArgs e)
        {
            var viewModel = (this.schedule.BindingContext as ViewModel);
            viewModel.SelectedDate = e.Datetime.Date.ToString("MMMM dd yyyy");
            viewModel.SelectedDateMeetings = new ObservableCollection<Meeting>();
            if (e.Appointments != null)
            {
                foreach (var item in e.Appointments)
                {
                    viewModel.SelectedDateMeetings.Add(item as Meeting);
                }
            }
        }

        void Schedule_SizeChanged(object sender, EventArgs e)
        {
            var viewModel = (gridView.BindingContext as ViewModel);
            if (viewModel == null)
                return;

            if ((sender as SfSchedule).Height > (sender as SfSchedule).Width &&  Device.RuntimePlatform != "UWP")
            {
                viewModel.ScheduleRowValue = 0;
                viewModel.ListViewRowValue = 1;
                viewModel.ScheduleColumnValue = 0;
                viewModel.ListViewColumnValue = 0;
                viewModel.ScheduleRowSpan = 1;
                viewModel.ListViewRowSpan = 1;
                viewModel.ScheduleColumnSpan = 2;
                viewModel.ListViewColumnSpan = 2;
            }
            else
            {
                viewModel.ScheduleRowValue = 0;
                viewModel.ListViewRowValue = 0;
                viewModel.ScheduleColumnValue = 0;
                viewModel.ListViewColumnValue = 1;
                viewModel.ScheduleRowSpan = 2;
                viewModel.ListViewRowSpan = 2;
                viewModel.ScheduleColumnSpan = 1;
                viewModel.ListViewColumnSpan = 1;
            }
        }

    }
}
