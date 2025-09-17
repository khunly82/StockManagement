using Microsoft.EntityFrameworkCore;
using StockManagement.Application.Interfaces;
using StockManagement.Domain.Entities;
using StockManagement.Infrastructure.Database;
using StockManagement.Infrastructure.Security;
using System.Security.Authentication;

namespace StockManagement.Application.Services
{
    public class AuthService(StockContext _dbContext) : IAuthService
    {
        public void AskResetPassword(string email)
        {
            throw new NotImplementedException();
        }

        public User Login(string email, string password)
        {
            User? user = _dbContext.Users.FirstOrDefault(u => EF.Functions.Like(u.Email, email.Trim())) 
                ?? throw new AuthenticationException();

            if (!HashUtils.VerifyPassword(password, user.EncodedPassword))
            {
                throw new AuthenticationException();
            }
            return user;
        }

        public bool ResetPassword(string token, string password)
        {
            throw new NotImplementedException();
        }
    }
}
