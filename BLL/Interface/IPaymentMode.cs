using BOL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
  public  interface IPaymentMode
    {
        PaymentModeModel GetPaymentModeDetails(PaymentModeModel model);
        List<PaymentModeModel> PaymentModeList();
       // int SavePaymentMode(PaymentModeModel mode);
        int SavePayment(OrderModel model);
        PaymentModeModel Getbyid(int id);
    }
}
