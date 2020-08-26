using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buisness.Interfaces.AdminPanel;
using Core.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.AdminPanel.ViewModels.Accounting;

namespace ShopCore.Controllers
{

    [Route("api/auth")]

    public class AuthController : Controller
    {
        private IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        [Authorize]
        [HttpGet("GetUsers")]
   
        public IActionResult GetUsers()
        {
            var returndata = _userService.GetUsersList();
            return Json(returndata);
        }
        [HttpPost("Login")]
        public IResponse<UserLoginResponseModel> Login([FromBody]UserLoginRequestModel request)
        {
            var returndata = _userService.Login(request);
            return returndata;
        }
    }
}