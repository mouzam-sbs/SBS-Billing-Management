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
    public class UserBusiness : IUserBusiness
    {
        private readonly IGenericPattern<User> tbl_UserRegistration;
        private readonly IGenericPattern<UserType> tbl_UserType;
        public UserBusiness()
        {
            tbl_UserRegistration = new GenericPattern<User>();
            tbl_UserType = new GenericPattern<UserType>();
        }

        public List<UserModel> UserRegistrationList()
        {
            List<UserModel> _userModel = new List<UserModel>();
            var Vardata = tbl_UserRegistration.GetAll().ToList();
            _userModel = (from item in Vardata
                          select new UserModel
                          {
                              Id = item.ID,
                              UserName = item.UserName,
                              Email = item.Email,
                              Password = item.Password,
                              RoleId = item.RoleId,
                              RoleName = item.Role.Name,
                              //UserTypeId = item.UserType != null ? (Int32)item.UserType.MainUserType : 0

                          }).OrderByDescending(x => x.Id).ToList();
            return _userModel;
        }

        public List<UserDetails> UserList()
        {
            List<UserDetails> _userList = new List<UserDetails>();
            var UserList = tbl_UserRegistration.GetAll().ToList();

            _userList = (from item in UserList
                         select new UserDetails
                         {
                             Id = item.ID,
                             UserName = item.UserName,
                             UserEmail = item.Email


                         }).ToList();
            return _userList;
        }

        public List<UserModel> GetUserTypesByMainUserType(int mainUserType)
        {
            List<UserModel> _UserModelList = new List<UserModel>();
            var UserTypeList = tbl_UserType.FindBy(m => m.MainUserType == mainUserType);
            if (UserTypeList != null && UserTypeList.Any())
            {
                _UserModelList = (from @item in UserTypeList
                                  select new UserModel
                                  {
                                      UserTypeId = @item.Id
                                  }).ToList();
            }
            return _UserModelList;
        }

        public UserModel GetById(int id)
        {
            UserModel _UserModel = new UserModel();
            var item = tbl_UserRegistration.GetById(id);


            _UserModel = new UserModel
            {

                Id = item.ID,
                UserName = item.UserName,
                Email = item.Email,
                Password = item.Password,
                RoleId = item.RoleId,
                RoleName = item.Role.Name,
            };
            return _UserModel;
        }
        public UserModel GetDetails(UserModel model)
        {
            model = model ?? new UserModel();
            if (model.Id != 0)
            {
                model.UserModelList = UserRegistrationList();

            }
            model.UserModelList = UserRegistrationList();

            return model;
        }
        public int Save(UserModel model)
        {
            model.RoleId = 4;
            model.UserTypeId = 4;
            User _UserModel = new User(model);
            if (model.Id != null && model.Id != 0)
            {
                tbl_UserRegistration.Upate(_UserModel);

            }
            else
            {

                tbl_UserRegistration.Insert(_UserModel);
            }

            return _UserModel.ID;
        }

    }
}
