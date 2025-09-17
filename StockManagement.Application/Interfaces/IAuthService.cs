using StockManagement.Domain.Entities;

namespace StockManagement.Application.Interfaces
{
    public interface IAuthService
    {
        User Login(string email, string password);
        bool ResetPassword(string token, string password);
        void AskResetPassword(string email);
    }
}
