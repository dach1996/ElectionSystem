using System.Linq;
using System;
using Dach.ElectionSystem.Models.Mail;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Dach.ElectionSystem.Services.Notification
{
    public class NotificationSendGrid : INotification
    {
        private readonly IConfiguration configuration;

        public NotificationSendGrid(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public bool SendMail(MailModel model)
        {
            var sendGridClient = new SendGridClient(configuration.GetSection("SendgridConfiguration:ApiKey").Value);
            var sendGridMessage = new SendGridMessage();
            sendGridMessage.SetFrom(configuration.GetSection("SendgridConfiguration:FromEmail").Value, configuration.GetSection("SendgridConfiguration:From").Value);
            var listEmail = model.To.Select(e => new EmailAddress(e)).ToList();
            sendGridMessage.AddTos(listEmail);
            sendGridMessage.Subject = model.Subject;
            sendGridMessage.SetTemplateId(model.Template);
            sendGridMessage.SetTemplateData(model.Params);
            var response = sendGridClient.SendEmailAsync(sendGridMessage).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                return true;
            return false;
        }
    }
}