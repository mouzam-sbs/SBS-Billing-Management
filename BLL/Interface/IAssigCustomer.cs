using BOL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
   public interface IAssigCustomer
    {
        AssignCustomerModel GetAssignDetails(AssignCustomerModel model);
        List<AssignCustomerModel> AssignedCustomerList();
        int Save(AssignCustomerModel mode);
        AssignCustomerModel Getbyid(int id);
    }
}
