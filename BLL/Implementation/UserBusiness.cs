 using BLL.Interface;
using BOL.Common;
using DAL.DataModel;
using DAL.GenericPattern.Implementation;
using DAL.GenericPattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Implementation
{
  public  class UserBusiness: IUserBusiness
    {
        private readonly IGenericPattern<User> _User;
        public UserBusiness()
        {
            _User = new GenericPattern<User>();
        }
        public UserDetails ValidateUserLoggedInn(UserDetails _UserDetails)
        {
            _UserDetails = _UserDetails ?? new UserDetails();
            if (!string.IsNullOrWhiteSpace(_UserDetails.UserEmail) && !string.IsNullOrWhiteSpace(_UserDetails.Password))
            {
                var user = _User.FindBy(m => m.Email.Trim().ToLower() == _UserDetails.UserEmail.Trim().ToLower() && m.Hash == _UserDetails.Password);
                if (user!=null)
                {
                    _UserDetails.Id = user.FirstOrDefault().ID;
                    _UserDetails.UserName = user.FirstOrDefault().UserName;
                    _UserDetails.Password = user.FirstOrDefault().Hash;
                    _UserDetails.UserEmail = user.FirstOrDefault().Email;
                    _UserDetails.RoleId = (int)user.FirstOrDefault().Role;
                    //_UserDetails.MessageIdEnum = (int)LoggedInnMessage.Success;
                    return _UserDetails;
                }
                //_UserDetails.MessageIdEnum = (int)LoggedInnMessage.Failure;
                return _UserDetails;
            }
            return _UserDetails;
        }

        public List<UserDetails> UserList()
        {
            List<UserDetails> _userList = new List<UserDetails>();
            var UserList = _User.GetAll().ToList();
          
            _userList = (from item in UserList
                         select new UserDetails
                             {
                               Id=item.ID,
                               UserName=item.UserName,
                               UserEmail=item.Email


                             }).ToList();
            return _userList;
        }
    }
}
