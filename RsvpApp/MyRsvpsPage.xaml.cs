using RsvpApp.Data;

namespace RsvpApp.Pages;

public partial class MyRsvpsPage : ContentPage
{
    public MyRsvpsPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (!Session.IsLoggedIn)
        {
            EventsList.ItemsSource = null;
            EventsList.EmptyView = "Log in to see this list. Guests can browse the Events tab.";
            return;
        }
        EventsList.EmptyView = "You haven't RSVP'd to anything yet.";
        EventsList.ItemsSource = SampleData.Attending;
    }

    private async void OnEventSelected(object sender, SelectionChangedEventArgs e)
    {
        await AppShell.OpenSelectedEvent(EventsList, e);
    }

    private async void OnLogOutClicked(object sender, EventArgs e)
    {
        await AppShell.LogOut();
    }
}