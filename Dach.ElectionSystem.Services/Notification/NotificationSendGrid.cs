using System;
using Dach.ElectionSystem.Models.Mail;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Dach.ElectionSystem.Services.Notification
{
    public class NotificationSendGrid : INotification
    {
        public bool SendMail(MailModel model)
        {
            var sendGridClient = new SendGridClient("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");
            var sendGridMessage = new SendGridMessage();
            sendGridMessage.SetFrom(model.From, "Election System Ecuador");
            sendGridMessage.AddTo(model.To);
            sendGridMessage.Subject=(model.Subject);
            sendGridMessage.SetTemplateId(model.Template);
            sendGridMessage.SetTemplateData(model.Params);
            var response = sendGridClient.SendEmailAsync(sendGridMessage).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                return true;
            return false;
        }
    }
}