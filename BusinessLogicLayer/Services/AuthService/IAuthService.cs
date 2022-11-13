using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.AuthService
{
    public interface IAuthService
    {
        public User Login(string username, string password);
        bool TestPassword(string username, string password);


    }
}
