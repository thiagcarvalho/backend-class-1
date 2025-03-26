namespace PetShop.Manager.Infrastructure.Email.Interfaces
{
    public interface IEmailService
    {
        bool SendEmail(string to, string message);
    }
}
