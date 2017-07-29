using BOL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
  public  interface IPaymentTransaction
    {
        PaymentTransactionModel GetPaymentTransactionDetails(PaymentTransactionModel model);
        List<PaymentTransactionModel> PaymentTransactionList();
        List<CustomerModel> CustomerList();

        int SavePaymentTransaction(PaymentTransactionModel model);
        PaymentTransactionModel GetbyId(int id);
    }
}
