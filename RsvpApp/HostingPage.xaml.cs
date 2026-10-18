using RsvpApp.Data;

namespace RsvpApp.Pages;

public partial class HostingPage : ContentPage
{
    public HostingPage()
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
        EventsList.EmptyView = "You aren't hosting any events yet.";
        EventsList.ItemsSource = SampleData.Hosting;
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