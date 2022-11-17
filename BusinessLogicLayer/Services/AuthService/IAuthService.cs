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
        UserInfo GetUserInfo(int userId);
        User Login(string username, string password);
        bool Register(string username, string password);
        bool TestPassword(string username, string password);



    }
}
