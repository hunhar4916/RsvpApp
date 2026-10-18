using RsvpApp.Data;

namespace RsvpApp.Pages;

public partial class EventListPage : ContentPage
{
    public EventListPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        EventsList.EmptyView = "No upcoming events.";
        EventsList.ItemsSource = SampleData.Events;
    }

    private async void OnEventSelected(object sender, SelectionChangedEventArgs e)
    {
        await AppShell.OpenSelectedEvent(EventsList, e);
    }

    private async void OnAddClicked(object sender, EventArgs e)
    {
        if (!Session.IsLoggedIn)
        {
            await DisplayAlert("Log In Needed", "Guests can't host events. Log in to add one.", "OK");
            return;
        }
        await Shell.Current.GoToAsync(nameof(AddEventPage));
    }

    private async void OnLogOutClicked(object sender, EventArgs e)
    {
        await AppShell.LogOut();
    }
}