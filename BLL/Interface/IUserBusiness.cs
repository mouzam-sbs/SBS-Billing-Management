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
        List<UserModel> UserRegistrationList();
        UserModel GetDetails(UserModel model);
        int Save(UserModel model);
        UserModel GetById(int id);
        List<UserDetails> UserList();
    }
}
