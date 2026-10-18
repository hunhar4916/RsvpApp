using RsvpApp.Data;

namespace RsvpApp.Pages;

public partial class AddEventPage : ContentPage
{
    public AddEventPage()
    {
        InitializeComponent();
        EventDatePicker.MinimumDate = DateTime.Today;
        EventDatePicker.Date = DateTime.Today;
        EventTimePicker.Time = new TimeSpan(18, 0, 0);
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        // Date and time pickers always have a value, so check the text fields
        if (!Session.AllFilled(TitleEntry.Text, DescriptionEditor.Text, LocationEntry.Text))
        {
            ErrorLabel.Text = "Please fill in every field.";
            ErrorLabel.IsVisible = true;
            return;
        }

        // Saving isn't built yet (Week 2)
        await DisplayAlert("Saved", "Event saving will be hooked up later.", "OK");
        await Shell.Current.GoToAsync("..");
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}