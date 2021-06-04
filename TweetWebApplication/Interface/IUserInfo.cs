using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetWebApplication.Models;

namespace TweetWebApplication.Interface
{
    public interface IUserInfo
    {

        public Task<UserInfo> RegisterUser(UserInfo userInfo);
        public Task<UserInfo> LoginUser(LoginClass login);
        public Task<bool> ResetPassword(ResetPasswordClass resetPassword);
        public Task<List<UserInfo>> GetAllUsers();

    }
}
