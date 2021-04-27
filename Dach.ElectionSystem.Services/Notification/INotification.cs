using Dach.ElectionSystem.Models.Mail;

namespace Dach.ElectionSystem.Services.Notification
{
    public interface INotification
    {
        bool SendMail(MailModel model);
    }
}