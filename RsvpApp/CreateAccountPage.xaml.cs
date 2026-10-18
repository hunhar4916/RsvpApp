using RsvpApp.Data;

namespace RsvpApp.Pages;

public partial class CreateAccountPage : ContentPage
{
    public CreateAccountPage()
    {
        InitializeComponent();
    }

    private async void OnCreateClicked(object sender, EventArgs e)
    {
        if (!Session.AllFilled(NameEntry.Text, EmailEntry.Text, PasswordEntry.Text))
        {
            ErrorLabel.Text = "Please fill in every field.";
            ErrorLabel.IsVisible = true;
            return;
        }

        // Saving users isn't built yet (Week 2), so just go back to Login
        await DisplayAlert("Account Created",
            "Saving accounts isn't hooked up yet. Log in with the demo account for now.", "OK");
        await Shell.Current.GoToAsync("..");
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}