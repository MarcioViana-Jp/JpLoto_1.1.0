using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using JpLoto.Application.Settings;

namespace JpLoto.Application.Services;

public class EmailService : IEmailService
{
    private readonly IOptions<SmtpSetting> _smtpSetting;

    public EmailService(IOptions<SmtpSetting> smtpSetting)
    {
        _smtpSetting = smtpSetting;
    }
    public async Task SendAsync(string to, string subject, string body)
    {
        var message = new MailMessage(_smtpSetting.Value.User, to, subject, body);

        message.Sender = new MailAddress(_smtpSetting.Value.User);

        using (var smtp = new SmtpClient(_smtpSetting.Value.Host, _smtpSetting.Value.Port))
        {
            smtp.EnableSsl = _smtpSetting.Value.EnableSSL;
            smtp.Credentials = new NetworkCredential(_smtpSetting.Value.User, _smtpSetting.Value.Password);
            await smtp.SendMailAsync(message);
        }
    }
}
