﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Common
{
   public class LoginModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Contact { get; set; }

        public string Area { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int? RoleId { get; set; }

        public string RoleName { get; set; }

        public string UserTypeName { get; set; }

        public int? UserTypeId { get; set; }

        public DateTime? CreatedDate { get; set; }

    }
}
