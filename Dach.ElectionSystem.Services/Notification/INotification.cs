using System.Threading.Tasks;
using Dach.ElectionSystem.Models.Mail;

namespace Dach.ElectionSystem.Services.Notification
{
    public interface INotification
    {
         Task<bool> SendMail(MailModel model);
    }
}