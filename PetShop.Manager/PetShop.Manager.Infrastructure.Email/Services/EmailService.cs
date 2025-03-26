using PetShop.Manager.Infrastructure.Email.Interfaces;

namespace PetShop.Manager.Infrastructure.Email.Services
{
    public class EmailService : IEmailService
    {
        public bool SendEmail(string to, string message)
        {
            Console.WriteLine($"Email sent to '{to}'");
            return true;
        }
    }
}
