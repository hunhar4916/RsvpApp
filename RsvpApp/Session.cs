namespace RsvpApp.Data;

// Keeps track of who is using the app right now.
// Week 2 uses hard-coded login info - a real database comes later.
public static class Session
{
    public const string DemoEmail = "test@rsvp.com";
    public const string DemoPassword = "password123";

    public static bool IsLoggedIn { get; private set; }
    public static string Name { get; private set; } = "";
    public static string Email { get; private set; } = "";
    public static string Phone { get; private set; } = "";

    public static bool TryLogIn(string email, string password)
    {
        if (email.Trim().Equals(DemoEmail, StringComparison.OrdinalIgnoreCase) && password == DemoPassword)
        {
            IsLoggedIn = true;
            Name = "Test User";
            Email = DemoEmail;
            Phone = "757-555-0123";
            return true;
        }
        return false;
    }

    public static void LogInAsGuest()
    {
        IsLoggedIn = false;
        Name = Email = Phone = "";
    }

    public static void LogOut() => LogInAsGuest();

    // Checks that every value has something typed in it
    public static bool AllFilled(params string?[] values) =>
        values.All(v => !string.IsNullOrWhiteSpace(v));
}