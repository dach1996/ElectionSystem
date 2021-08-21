using System.Linq;
using Dach.ElectionSystem.Models.Mail;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Dach.ElectionSystem.Services.Notification
{
    public class NotificationSendGrid : INotification
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<NotificationSendGrid> _logger;

        public NotificationSendGrid(IConfiguration configuration, ILogger<NotificationSendGrid> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        public bool SendMail(MailModel model)
        {
            var sendGridClient = new SendGridClient(_configuration.GetSection("SendgridConfiguration:ApiKey").Value);
            var sendGridMessage = new SendGridMessage();
            sendGridMessage.SetFrom(_configuration.GetSection("SendgridConfiguration:FromEmail").Value, _configuration.GetSection("SendgridConfiguration:From").Value);
            var listEmail = model.To.Select(e => new EmailAddress(e)).ToList();
            sendGridMessage.AddTos(listEmail);
            sendGridMessage.Subject = model.Subject;
            sendGridMessage.SetTemplateId(model.Template);
            sendGridMessage.SetTemplateData(model.Params);
            var response = sendGridClient.SendEmailAsync(sendGridMessage).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                return true;
            else
                _logger.LogError("Error en servico de correo SendGrid: '{@Messagge}'", JsonConvert.SerializeObject(response));
            return false;
        }
    }
}