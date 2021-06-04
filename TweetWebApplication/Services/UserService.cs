using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetWebApplication.Interface;
using TweetWebApplication.Models;

namespace TweetWebApplication.Services
{
    public class UserService : IUserInfo
    {
        private readonly ISqlDataRepository sqldataRepository;
        //dependency injection
        public UserService(ISqlDataRepository _sqldataRepository)
        {
            sqldataRepository = _sqldataRepository;
        }
        public async Task<List<UserInfo>> GetAllUsers()
        {
            try
            {
                var users = await sqldataRepository.GetAllUsers();
                foreach (var user in users)
                {
                    user.Password = "";
                }
                return users;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public async Task<UserInfo> LoginUser(LoginClass login)
        {
            try
            {
                var user = await sqldataRepository.GetUserByEmailAddress(login.emailId);
                if (user.Password.Trim() == login.password)
                {
                    user.Password = "";
                    return user;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public async Task<UserInfo> RegisterUser(UserInfo userInfo)
        {
            try
            {
                var existingUser = await sqldataRepository.GetUserByEmailAddress(userInfo.EmailAddress);
                
                if(existingUser == null)
                {
                    if(userInfo.FirstName.Length > 0)
                    {
                        if(userInfo.EmailAddress.Length > 0)
                        {
                            if(userInfo.Password.Length > 0)
                            {
                                var user = await sqldataRepository.AddUser(userInfo);
                                user.Password = "";
                                return user;
                            }

                            else
                            {
                                throw new Exception("Please provide a valid password");
                            }
                        }

                        else
                        {
                            throw new Exception("Email address cannot be empty");
                        }
                    }

                    else
                    {
                        throw new Exception("Firstname is required");
                    }
                    
                   
                }

                else
                {
                    throw new Exception("Duplicate user. You alrady have an acount!!");
                }
                
                
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public async Task<bool> ResetPassword(ResetPasswordClass resetPassword)
        {
            try
            {
                var user = await sqldataRepository.GetUserByEmailAddress(resetPassword.emailId);
                if (resetPassword.oldPassword.Length > 0)
                {
                    if (user.Password.Trim() == resetPassword.oldPassword)
                    {
                        user.Password = resetPassword.newPassword;
                        var userUpdated = await sqldataRepository.ModifyUser(user);
                        return true;
                    }
                    else
                    {
                        throw new Exception("Password not matching");
                    }
                }
                else
                {
                    throw new Exception("Please provide old password");
                }
                //return false;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
