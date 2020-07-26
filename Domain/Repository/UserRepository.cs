
using Database.Interfaces;
using Models.AdminPanel.Database;
using Models.AdminPanel.Database.Accounting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Database.Repository
{
   public class UserRepository:BaseRepository<User>,IUserRepository
    {
        public bool AddUser(User entity)
        {
            
           using(var dbContextTransaction = Database.Database.BeginTransaction())
            {
                try
                {
                    if (AddUser(entity))
                {
                    dbContextTransaction.Commit();
                        return true;
                        
                }
                else
                {
                        dbContextTransaction.Rollback();
                        return false;
                }
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
            
        }
        public User GetUser(string UserName,string Password)
        {
            return Database.User.Where(m => m.UserName == UserName && m.Password == Password).FirstOrDefault();
        }

        public List<Roles> GetUserRoles(int UserID)
        {
            return Database.UserRoles.Include(m=>m.Role).Where(m => m.UserID == UserID).Select(m => m.Role).ToList();
        }
    }
}
