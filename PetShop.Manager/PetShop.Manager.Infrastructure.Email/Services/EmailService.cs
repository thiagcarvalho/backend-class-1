using PetShop.Manager.Application.Contracts.Interfaces.Services;
using System.Net.Mail;
using System.Net;

namespace PetShop.Manager.Infrastructure.Email.Services
{
    public class EmailService : IEmailService
    {
        public bool SendEmail(string to, string message)
        {
            try
            {
                using SmtpClient smtpClient = new();
                smtpClient.Host = "localhost";
                smtpClient.Credentials = new NetworkCredential("admin", "123456");
                smtpClient.Send(
                    new MailMessage(
                        from: new MailAddress("no-reply@petshopmanager.com"),
                        to: new MailAddress(to))
                    {
                        Body = message
                    });
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
