
using Models.AdminPanel.Database;
using Models.AdminPanel.Database.Accounting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Interfaces
{
    public interface IUserRepository:IBaseRepository<User>
    {
        bool AddUser(User user);
        User GetUser(string UserName, string Password);
        List<Roles> GetUserRoles(int UserID);
        
    }
}
