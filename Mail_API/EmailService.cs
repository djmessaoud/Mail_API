using Microsoft.Extensions.Options;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;

namespace Mail_API;

public class EmailService
{
    private readonly SmtpConfig _smtpSettings;
    
    //Constuctor to initialize the service with smtp configuration
    public EmailService(IOptions<SmtpConfig> SmtpConfig) 
    {
        _smtpSettings = SmtpConfig.Value;
    }
    
    //Function to send the email
    public string sendEmail(EmailFromPOST emailData)
    {
        //Creating an Email message using Mime
            using (MimeMessage emailMessage = new MimeMessage())
            {
                //from
                MailboxAddress from = new MailboxAddress(_smtpSettings.username, _smtpSettings.username);
                emailMessage.From.Add(from);
                //Add receivers from POST request to Email Message (configuration)
                foreach (var receiver in emailData.receivers)
                {
                    //receiverX
                    emailMessage.To.Add(new MailboxAddress(receiver,receiver));
                }
                //subject
                emailMessage.Subject = emailData.subject;
                //body
                BodyBuilder emailBodyBuilder = new BodyBuilder();
                emailBodyBuilder.TextBody = emailData.body;
                emailMessage.Body = emailBodyBuilder.ToMessageBody(); 
                //send mail
                using (SmtpClient mailClient = new SmtpClient())
                {
                    mailClient.Connect(_smtpSettings.server, _smtpSettings.port, MailKit.Security.SecureSocketOptions.Auto);
                   // mailClient.Authenticate(_smtpSettings.username, _smtpSettings.password);
                   var result=  mailClient.Send(emailMessage);
                   mailClient.Disconnect(true); 
                   //Return Success if the mail has been sent, otherwise, return the result message.
                   if (result == "OK") return "Success";
                   else return result;
                    
                }
            }
    }
}