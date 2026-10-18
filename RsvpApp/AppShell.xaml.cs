using RsvpApp.Pages;

namespace RsvpApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Pages that get pushed on top (they get a back arrow)
        Routing.RegisterRoute(nameof(CreateAccountPage), typeof(CreateAccountPage));
        Routing.RegisterRoute(nameof(EventDetailsPage), typeof(EventDetailsPage));
        Routing.RegisterRoute(nameof(AddEventPage), typeof(AddEventPage));
        Routing.RegisterRoute(nameof(RsvpPage), typeof(RsvpPage));
        Routing.RegisterRoute(nameof(AttendeeListPage), typeof(AttendeeListPage));
    }

    // Shared helpers used by several pages
    public static Task GoToEventList() => Current.GoToAsync("//main/events");

    public static Task LogOut()
    {
        Data.Session.LogOut();
        return Current.GoToAsync("//login");
    }

    public static async Task OpenSelectedEvent(CollectionView list, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Models.Event ev)
        {
            list.SelectedItem = null; // so the same card can be tapped again
            await Current.GoToAsync($"{nameof(EventDetailsPage)}?id={ev.Id}");
        }
    }
}