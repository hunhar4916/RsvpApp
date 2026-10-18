using RsvpApp.Data;

namespace RsvpApp.Pages;

[QueryProperty(nameof(EventId), "id")]
public partial class AttendeeListPage : ContentPage
{
    public AttendeeListPage()
    {
        InitializeComponent();
    }

    public string EventId
    {
        set
        {
            var ev = SampleData.GetById(int.Parse(value));
            if (ev == null) return;
            HeaderLabel.Text = $"{ev.Attendees.Count} going to {ev.Title}";
            AttendeesList.ItemsSource = ev.Attendees;
        }
    }
}