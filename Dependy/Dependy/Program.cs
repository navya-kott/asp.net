// See https://aka.ms/new-console-template for more information
using Dependy;

Console.WriteLine("Hello, World!");

IMessageService messageService = new SmsService();
Messenger messenger = new Messenger(messageService);
messenger.sendEmail("poda patti");
