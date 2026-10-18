using RsvpApp.Models;

namespace RsvpApp.Data;

// Hard-coded events for Week 2
public static class SampleData
{
    public static List<Event> Events { get; } = new()
    {
        new Event
        {
            Id = 1, Title = "Fall Food Truck Festival",
            Description = "Local food trucks, live music, and lawn games for the whole family.",
            Date = new DateTime(2026, 10, 24, 12, 0, 0), Location = "Mount Trashmore Park",
            Host = "City Events Team", Attendees = new() { "Test User", "Jordan Lee", "Maria Gomez" }
        },
        new Event
        {
            Id = 2, Title = "Study Group: Mobile Dev",
            Description = "Weekly study session. Bring your laptop and questions.",
            Date = new DateTime(2026, 10, 27, 18, 30, 0), Location = "Campus Library, Room 204",
            Host = "Test User", Attendees = new() { "Chris Park", "Ava Brown" }
        },
        new Event
        {
            Id = 3, Title = "Halloween Costume Party",
            Description = "Costume contest at 9 PM. Snacks and drinks provided.",
            Date = new DateTime(2026, 10, 31, 20, 0, 0), Location = "Community Center Hall",
            Host = "Neighborhood Association", Attendees = new() { "Test User", "Sam Carter" }
        },
        new Event
        {
            Id = 4, Title = "Beach Cleanup",
            Description = "Gloves and bags provided. Meet at the lifeguard stand.",
            Date = new DateTime(2026, 11, 7, 9, 0, 0), Location = "Oceanfront at 24th St",
            Host = "Test User", Attendees = new() { "Riley Adams" }
        },
    };

    public static Event? GetById(int id) => Events.FirstOrDefault(e => e.Id == id);

    // Events the logged-in test user is going to
    public static List<Event> Attending =>
        Events.Where(e => e.Attendees.Contains(Session.Name)).ToList();

    // Events the logged-in test user is hosting
    public static List<Event> Hosting =>
        Events.Where(e => e.Host == Session.Name).ToList();
}