using System.Linq;
using Dach.ElectionSystem.Models.Mail;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

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
        public async Task<bool> SendMail(MailModel model)
        {
            var sendEmailConfig = _configuration.GetSection("SendMails").Value;
            var sendMailIsBool = bool.TryParse(sendEmailConfig, out var sendMail);
            if (sendMailIsBool && !sendMail)
            {
                _logger.LogWarning("La configuración de Email: '{@configMail}' es: '{@value}'", "SendMails", sendMail);
                return false;
            }
            var mailtestConfig = _configuration.GetSection("SendOnlyTest").Value;
            _ = bool.TryParse(mailtestConfig, out var mailTest);
            if (mailTest)
            {
                var emailTest = _configuration.GetSection("EmailTest").Value;
                var sendGridClient = new SendGridClient(_configuration.GetSection("SendgridConfiguration:ApiKey").Value);
                var sendGridMessage = new SendGridMessage();
                sendGridMessage.SetFrom(_configuration.GetSection("SendgridConfiguration:FromEmail").Value, _configuration.GetSection("SendgridConfiguration:From").Value);
                sendGridMessage.AddTo(emailTest, string.Empty);
                sendGridMessage.Subject = model.Subject;
                sendGridMessage.SetTemplateId(model.Template);
                sendGridMessage.SetTemplateData(model.Params);
                var response = await sendGridClient.SendEmailAsync(sendGridMessage);
                if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                    _logger.LogInformation("Se ha enviado al mail Test: '{@MailTest}'", emailTest);
                else
                    _logger.LogInformation("No se pudo enviar mail Test: '{@MailTest}'", emailTest);
                return response.StatusCode == System.Net.HttpStatusCode.Accepted;
            }
            var maxMail = 20;
            var listEmail = model.To.Select(e => new EmailAddress(e)).ToList();
            var countEmails = ((decimal)listEmail.Count) / maxMail;
            var totalSkyps = Math.Ceiling(countEmails);
            var totalEmailsSend = 0;
            for (int skyp = 0; skyp < totalSkyps; skyp++)
            {
                var mailsToSend = listEmail.Skip(skyp * maxMail).Take(maxMail).ToList();
                var sendGridClient = new SendGridClient(_configuration.GetSection("SendgridConfiguration:ApiKey").Value);
                var sendGridMessage = new SendGridMessage();
                sendGridMessage.SetFrom(_configuration.GetSection("SendgridConfiguration:FromEmail").Value, _configuration.GetSection("SendgridConfiguration:From").Value);
                sendGridMessage.AddTos(mailsToSend);
                sendGridMessage.AddTo("dach19962012@gmail.com", "Danny Cárdenas");
                sendGridMessage.Subject = model.Subject;
                sendGridMessage.SetTemplateId(model.Template);
                sendGridMessage.SetTemplateData(model.Params);
                var response = await sendGridClient.SendEmailAsync(sendGridMessage);
                if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    totalEmailsSend += mailsToSend.Count;
                    _logger.LogInformation("Se ha enviado '{@CountMails}' mails", mailsToSend.Count);
                }
                else
                    _logger.LogError("Error en servico de correo SendGrid: '{@Messagge}'", JsonConvert.SerializeObject(response));
            }
            if (totalEmailsSend != listEmail.Count)
                _logger.LogError("Se enviaron '{@MailsSend}' de un total de '{@MailsToSend}'", totalEmailsSend, listEmail.Count);
            return false;
        }
    }
}