using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Common
{
   public class UserModel
    {
        public int Id { get; set; }
        //public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Password Does Not Match")]
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
        public int UserTypeId { get; set; }
        public string Address { get; set; }
        //public int? DesignationId { get; set; }
        //public string DesignationName { get; set; }
        //public long? Mobile { get; set; }
        //public string Gender { get; set; }
        //public byte[] Photo { get; set; }

        //public int MessageIdEnum { get; set; }

        public List<UserModel> UserModelList { get; set; }
        //public List<DesignationModel> DesignationModelList { get; set; }

    }
}
