using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.AdminPanel.ViewModels.Accounting
{
    public class UserLoginRequestModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class UserLoginResponseModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string UserFullName { get; set; }
        public string Token { get; set; }
    }
}
