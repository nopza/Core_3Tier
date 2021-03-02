using DAL.Entities;
using DAL.Functions;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.UserLogic
{
    public class UserLogic
    {
        private IUser _user = new UserFunctions();

        //ADD A NEW USER
        public async Task<Boolean> CreateNewUser(string username, string emailAddress, string password, int authLevelId)
        {
            try
            {
                var result = await _user.AddUser(username, emailAddress, password, authLevelId);
                if (result.Id > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception error)
            {
                return false;
            }
        }

        //GET ALL USERS
        public async Task<List<User>> GetAllUsers()
        {
            List<User> users = await _user.GetAllUsers();
            return users;
        }
    }
}
