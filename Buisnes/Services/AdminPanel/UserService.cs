using Buisness.Interfaces;
using Buisness.Interfaces.AdminPanel;
using Core.AdminPanel.Mappers;
using Models.AdminPanel.Database.Accounting;
using Models.AdminPanel.ViewModels.Accounting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Shared;
using Core.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Buisness.Services.AdminPanel
{
    public class UserService : BaseService, IUserService
    {
        private IConfiguration _configuration;
        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool AddUser(UserViewModel model)
        {
            if (model.Password != null)
            {
                model.Password = Core.Shared.Encryption.CreateMD5(model.Password);
            }
            if (UserRepository.Add(Transformer.AsDatabaseModel(model)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public IResponse<UserLoginResponseModel> Login(UserLoginRequestModel model)
        {
            try
            {
                var loginUser = UserRepository.GetUser(model.UserName, Encryption.CreateMD5(model.Password));

                if (loginUser == null)
                {
                    return Fail<UserLoginResponseModel>("User Not Found");
                }
                else
                {
                    var UserRoles = UserRepository.GetUserRoles(loginUser.ID);
                    var returnRolesName = new List<string>();
                    foreach (var role in UserRoles)
                    {
                        returnRolesName.Add(role.RoleName);
                    }
                    //token generation

                    //security key
                    string securityKey = _configuration.GetSection("AppSettings").GetSection("JWTKey").Value;
                    //symetric security key
                    var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
                    //signIn Credentials
                    var signInCredentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
                    var claims = new List<Claim>();

                    claims.Add(new Claim(ClaimTypes.NameIdentifier, loginUser.UserName));
                    foreach(var role in UserRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.Description));
                    }
               
                    //token
                    var token = new JwtSecurityToken(
                        issuer: "api1",
                        audience: "api1",
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: signInCredentials,
                        claims: claims
                        );


                    return Ok<UserLoginResponseModel>(new UserLoginResponseModel()
                    {
                        ID = loginUser.ID,
                        UserName = loginUser.UserName,
                        UserFullName=loginUser.FirstName+" "+loginUser.LastName,
                        Token=new JwtSecurityTokenHandler().WriteToken(token)
                    }); 
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<UserViewModel> GetUsersList()
        {
            var result= UserRepository.Get();
            return result.Select(m => new UserViewModel() {
                FirstName = m.FirstName,
                LastName = m.LastName,
                BirthDate = m.BirthDate,
                PIN = m.PIN,
                ID = m.ID,
                IsDeleted = m.IsDeleted,
                Address = m.Address,
                UserName = m.UserName,
                UserRoles = m.Roles.Select(n =>new RolesModel() {
                    RoleName=n.Role.RoleName,
                    Description=n.Role.Description,
                    ID=n.Role.ID
                }).ToList()
            }).ToList();
        }
        public UserViewModel GetUserByID(int userID)
        {
            return Transformer.AsViewModel(UserRepository.Get().Where(m => m.ID == userID).FirstOrDefault());
        }
        public UserViewModel UpdateUser(UserViewModel model)
        {
            var user = UserRepository.Get().Where(m => m.ID == model.ID).FirstOrDefault();
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.BirthDate = model.BirthDate;
            user.Address = model.Address;

           return Transformer.AsViewModel(UserRepository.Update(user));
        }
    }
}
