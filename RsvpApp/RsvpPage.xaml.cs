using RsvpApp.Data;

namespace RsvpApp.Pages;

[QueryProperty(nameof(EventId), "id")]
public partial class RsvpPage : ContentPage
{
    public RsvpPage()
    {
        InitializeComponent();

        // Logged in: fill in hard-coded info. Guest: leave everything blank.
        if (Session.IsLoggedIn)
        {
            NameEntry.Text = Session.Name;
            EmailEntry.Text = Session.Email;
            PhoneEntry.Text = Session.Phone;
            GuestCountEntry.Text = "1";
        }
    }

    public string EventId
    {
        set
        {
            var ev = SampleData.GetById(int.Parse(value));
            EventTitleLabel.Text = ev == null ? "RSVP" : "RSVP for " + ev.Title;
        }
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (!Session.AllFilled(NameEntry.Text, EmailEntry.Text, PhoneEntry.Text, GuestCountEntry.Text))
        {
            ErrorLabel.Text = "Please fill in every field.";
            ErrorLabel.IsVisible = true;
            return;
        }

        // Saving RSVPs isn't built yet (Week 2)
        await DisplayAlert("RSVP Sent", "RSVP saving will be hooked up later.", "OK");
        await Shell.Current.GoToAsync("..");
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}