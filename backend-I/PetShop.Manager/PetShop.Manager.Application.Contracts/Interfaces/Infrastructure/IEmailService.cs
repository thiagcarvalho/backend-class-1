namespace PetShop.Manager.Application.Contracts.Interfaces.Infrastructure 
{
    public interface IEmailService
    {
        bool SendEmail(string to, string message);
    }
}
