public interface INotificationChannel
{
    void SendNotification(string message, User user);
}