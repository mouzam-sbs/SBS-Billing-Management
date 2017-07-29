using BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL.Common;
using DAL.GenericPattern.Implementation;
using DAL.DataModel;
using DAL.GenericPattern.Interface;

namespace BLL.Implementation
{
    public class AssignCustomerBs : IAssigCustomer
    {
        private readonly IGenericPattern<AssignCustomer> _AssignCustomer;
        private readonly IGenericPattern<User> _User;

        public AssignCustomerBs()
        {
            _AssignCustomer = new GenericPattern<AssignCustomer>();
            _User = new GenericPattern<User>();

        }

        public List<AssignCustomerModel> AssignedCustomerList()
        {
            throw new NotImplementedException();
        }

        public AssignCustomerModel GetAssignDetails(AssignCustomerModel model)
        {
            throw new NotImplementedException();
        }

        public AssignCustomerModel Getbyid(int id)
        {
            throw new NotImplementedException();
        }

        public int Save(AssignCustomerModel model)
        {
            AssignCustomer _assignCustomer = new AssignCustomer(model);
            if (model.Id != 0 && model.Id != null)
            {
                _AssignCustomer.Upate(_assignCustomer);

            }
            else
            {
                _assignCustomer = _AssignCustomer.Insert(_assignCustomer);
            }

            return _assignCustomer.Id;
        }
    }
}
