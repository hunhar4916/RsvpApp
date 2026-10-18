using RsvpApp.Data;

namespace RsvpApp.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Clear the form every time we come back (like after logging out)
        EmailEntry.Text = "";
        PasswordEntry.Text = "";
        ErrorLabel.IsVisible = false;
    }

    private async void OnLogInClicked(object sender, EventArgs e)
    {
        if (!Session.AllFilled(EmailEntry.Text, PasswordEntry.Text))
        {
            ShowError("Please enter your email and password.");
            return;
        }
        if (!Session.TryLogIn(EmailEntry.Text, PasswordEntry.Text))
        {
            ShowError("Email or password is incorrect.");
            return;
        }
        await AppShell.GoToEventList();
    }

    private async void OnGuestClicked(object sender, EventArgs e)
    {
        Session.LogInAsGuest();
        await AppShell.GoToEventList();
    }

    private async void OnCreateAccountClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(CreateAccountPage));
    }

    private void ShowError(string message)
    {
        ErrorLabel.Text = message;
        ErrorLabel.IsVisible = true;
    }
}