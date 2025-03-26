namespace PetShop.Manager.Application.Contracts.Interfaces.Services 
{
    public interface IEmailService
    {
        bool SendEmail(string to, string message);
    }
}
