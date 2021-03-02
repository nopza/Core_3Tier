using Core_3Tier.Models;
using LOGIC.UserLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_3Tier.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserLogic userLogic = new UserLogic();

        //ADD-USER
        [Route("add")]
        [HttpPost]
        public async Task<Boolean> AddUser(string username, string emailAddress, string password, int authLevelId)
        {
            bool result = await userLogic.CreateNewUser(username, emailAddress, password, authLevelId);
            return result;
        }

        [Route("all")]
        [HttpGet]
        public async Task<List<UserViewModel>> GetAllUsers()
        {
            List<UserViewModel> userList = new List<UserViewModel>();
            var users = await userLogic.GetAllUsers();
            if (users.Count > 0)
            {
                foreach (var user in users)
                {
                    UserViewModel currentUser = new UserViewModel
                    {
                        AuthLevel = user.AuthLevelRefId,
                        EmailAddress = user.Email,
                        UserId = user.Id,
                        Username = user.Username
                    };
                    userList.Add(currentUser);
                }                
            }
            return userList;
        }
    }
}
