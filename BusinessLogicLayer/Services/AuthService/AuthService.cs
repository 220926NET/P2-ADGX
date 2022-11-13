using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            this.authRepository = authRepository;

        }
        public User Login(string username, string password)
        {
            return authRepository.GetUser(username, password);
        }

        public bool TestPassword(string username, string password)
        {
            if (authRepository.LookupUser(username))
            {
                string salt = authRepository.GetUserSalt(username);
                return authRepository.VerifyPassword(username, password, salt);
            }
            return false;
        }
    }
}
