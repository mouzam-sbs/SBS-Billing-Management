using BOL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface ICustomerPaymentPlan
    {
        List<CustomerPaymentPlanModel> CustomerPaymentPlanList();
        List<OrderModel> OrderList();
        List<CustomerModel> CustomerList();
        List<PaymentPlanMasterModel> PaymentPlanMasterList();

        CustomerPaymentPlanModel GetDetails(CustomerPaymentPlanModel model);

        int Save(CustomerPaymentPlanModel model);

        CustomerPaymentPlanModel GetById(int id);
    }
}
