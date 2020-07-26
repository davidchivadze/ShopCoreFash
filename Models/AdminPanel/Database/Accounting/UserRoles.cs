using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.AdminPanel.Database.Accounting
{
    public class UserRoles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserID { get; set; }
        [ForeignKey("Role")]
        [Required]
        public int RoleID { get; set; }

         public User User { get; set; }
         public Roles Role { get; set; }
    }
}
