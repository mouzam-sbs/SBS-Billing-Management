using BOL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
  public  interface IPayments
    {
        PaymentModel GetPaymentDetails(PaymentModel model);
        List<PaymentModel> PaymentList();
        int SavePayment(PaymentModel model);
        PaymentModel Getbyid(int id);
    }
}
