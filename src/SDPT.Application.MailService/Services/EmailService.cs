using System.Net;
using System.Net.Mail;

namespace SDPT.Application.MailService.Services
{
  public class EmailService {

    private string emailAddress = "email";

    public void SendEmail(string sendTo, string intro) {
      var smtpClient = new SmtpClient("smtp.gmail.com")
      {
          Port = 587,
          Credentials = new NetworkCredential("email", "password"),
          EnableSsl = true,
      };
          
      var mailMessage = new MailMessage
      {
          From = new MailAddress(emailAddress),
          Subject = "There are some new demands that match your housing information.",
          Body = @"<h1>Hello, </h1>",
          IsBodyHtml = true,
      };
      mailMessage.To.Add(sendTo);

      smtpClient.Send(mailMessage);

    }
  }

}