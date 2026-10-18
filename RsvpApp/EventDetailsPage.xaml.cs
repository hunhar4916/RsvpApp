using RsvpApp.Data;

namespace RsvpApp.Pages;

// Receives the event id from the URL, e.g. "EventDetailsPage?id=2"
[QueryProperty(nameof(EventId), "id")]
public partial class EventDetailsPage : ContentPage
{
    private int _eventId;

    public EventDetailsPage()
    {
        InitializeComponent();
    }

    public string EventId
    {
        set
        {
            _eventId = int.Parse(value);
            var ev = SampleData.GetById(_eventId);
            if (ev == null) return;

            TitleLabel.Text = ev.Title;
            DateLabel.Text = "Date: " + ev.DateText;
            TimeLabel.Text = "Time: " + ev.TimeText;
            LocationLabel.Text = "Location: " + ev.Location;
            HostLabel.Text = "Hosted by " + ev.Host;
            DescriptionLabel.Text = ev.Description;
        }
    }

    private async void OnRsvpClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(RsvpPage)}?id={_eventId}");
    }

    private async void OnWhosComingClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(AttendeeListPage)}?id={_eventId}");
    }
}