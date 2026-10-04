# Notification System

Send a Notification to User

Notification types 
- Email
- Sms

## Entities
- User 
  - Id
  - Name
  - Email
  - PhoneNumber

## Service
- NotificationService
  - Email Notificatino
  - SMS Notification

## Interface
- INotificationService
  - SendNotification()

## Implementations
- EmailNotificationService
- SMSNotificationService