namespace RsvpApp.Models;

public class Event
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public DateTime Date { get; set; }
    public string Location { get; set; } = "";
    public string Host { get; set; } = "";
    public List<string> Attendees { get; set; } = new();

    // Used by the event cards and the details page
    public string DateText => Date.ToString("ddd, MMM d, yyyy");
    public string TimeText => Date.ToString("h:mm tt");
}