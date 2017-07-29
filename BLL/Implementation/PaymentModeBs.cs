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
    public class PaymentModeBs : IPaymentMode
    {
        private readonly IGenericPattern<PaymentMode> _paymentMode;
        private readonly IGenericPattern<Payment> _payment;

        public PaymentModeBs()
        {
            _paymentMode=new GenericPattern<PaymentMode>();
            _payment = new GenericPattern<Payment>();
        }
        public PaymentModeModel Getbyid(int id)
        {
            throw new NotImplementedException();
        }

        public PaymentModeModel GetPaymentModeDetails(PaymentModeModel model)
        {
            throw new NotImplementedException();
        }

        public List<PaymentModeModel> PaymentModeList()
        {
            var res = _paymentMode.GetAll().ToList();

            List<PaymentModeModel> paymentmodelist = new List<PaymentModeModel>();
            paymentmodelist = (from item in res
                               select new PaymentModeModel
                               {
                                   Id = item.Id,
                                   Name = item.Name
                               }).ToList();
            return paymentmodelist;
        }


        public int SavePayment(OrderModel model)
        {
            Payment ob2=null;
            PaymentModel obj = new PaymentModel();
            obj.OrderId = model.OrderID;
            obj.CustomerId = model.CustomerID;
            obj.TotalAmount = model.GrandTotal;
            //obj.BalanceAmount = model.Balance;
            //obj.PaidAmount = model.AmountPaid;
            obj.PaymentDate = model.PaymentDate;
            obj.CreatedDate = model.CreatedOn;
            obj.Status = model.Status;
            Payment model1 = new Payment(obj);

            if (model.ID != 0)
            {
                _payment.Upate(model1);
                
            }
            else
            {
               ob2= _payment.Insert(model1);
            }

            return ob2.Id;
        }
    }
}
