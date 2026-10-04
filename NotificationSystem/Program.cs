User user1 = new User("Sanjeev", "sanjeev.rawat@gmail.com","7973564308");

User user2 = new User("Samridh", "samridh.paatni@gmail.com", "9087675654");

EmailNotificationChannel emailService = new EmailNotificationChannel();
SMSNotificationChannel smsService = new SMSNotificationChannel();

NotificationSystem notificationSystem = new NotificationSystem(emailService);

notificationSystem.SendNotification("Hello", user1);

notificationSystem = new NotificationSystem(smsService);

notificationSystem.SendNotification("Hi", user2);