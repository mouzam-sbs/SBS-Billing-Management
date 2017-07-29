using BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL.Common;
using DAL.GenericPattern.Interface;
using DAL.DataModel;
using DAL.GenericPattern.Implementation;

namespace BLL.Implementation
{
    public class PaymentsBs : IPayments
    {
        private readonly IGenericPattern<Payment> _Payment;

        public PaymentsBs()
        {
            _Payment = new GenericPattern<Payment>();
        }

        public PaymentModel Getbyid(int id)
        {
            throw new NotImplementedException();
        }

        public PaymentModel GetPaymentDetails(PaymentModel model)
        {
            throw new NotImplementedException();
        }

        public List<PaymentModel> PaymentList()
        {
            throw new NotImplementedException();
        }

        public int SavePayment(PaymentModel model)
        {
            Payment payment = new Payment(model);
            if (model.Id!=0)
            {
                _Payment.Upate(payment);
            }
            else
            {
                _Payment.Insert(payment);
            }

            return payment.Id;
        }
    }
}
