using BOL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BLL.Interface
{
   public interface IUserBusiness
    {
        UserDetails ValidateUserLoggedInn(UserDetails _UserDetails);

        List<UserDetails> UserList();
    }
}
