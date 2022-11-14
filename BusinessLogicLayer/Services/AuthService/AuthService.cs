using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            this._authRepository = authRepository;

        }


        public User Login(string username, string password)
        {
            return _authRepository.GetUser(username, password);
        }

        public User Register(string username, string password)
        {
            User user = new();
            user.Id = _authRepository.CreateUser(username, password);
            user.Username = username;
            user.Password = password;
            return user;
        }

        public bool TestPassword(string username, string password)
        {
            if (_authRepository.LookupUser(username))
            {
                string salt = _authRepository.GetUserSalt(username);
                return _authRepository.VerifyPassword(username, password, salt);
            }
            return false;
        }
    }
}
