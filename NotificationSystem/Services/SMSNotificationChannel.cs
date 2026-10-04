public class SMSNotificationChannel : INotificationChannel
{
    public void SendNotification(string message, User user)
    {
        Console.WriteLine($"Sent SMS to {user.Name} at {user.PhoneNumber} : {message}");
    }
}