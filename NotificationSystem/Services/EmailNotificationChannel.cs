public class EmailNotificationChannel : INotificationChannel
{
    public void SendNotification(string message, User user)
    {
        Console.WriteLine($"Sent Email to {user.Name} at {user.Email} : {message}");
    }
}