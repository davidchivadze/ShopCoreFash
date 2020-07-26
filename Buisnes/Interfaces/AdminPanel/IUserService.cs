
using Core.Helpers;
using Database.Interfaces;
using Models.AdminPanel.ViewModels.Accounting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Interfaces.AdminPanel
{
    public interface IUserService:IBaseService
    {
        List<UserViewModel> GetUsersList();
        IResponse<UserLoginResponseModel> Login(UserLoginRequestModel model);

    }
}
