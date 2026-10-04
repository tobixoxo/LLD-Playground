public class NotificationSystem
{
    private readonly INotificationChannel _notificationChannel;

    public NotificationSystem (INotificationChannel notificationChannel)
    {
        _notificationChannel = notificationChannel;
    }

    public void SendNotification(string message, User user)
    {
        _notificationChannel.SendNotification(message, user);
    }
}