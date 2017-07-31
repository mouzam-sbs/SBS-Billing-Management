using BLL.Interface;
using BOL.Common;
using BOL.Helpers.Enums;
using DAL.DataModel;
using DAL.GenericPattern.Implementation;
using DAL.GenericPattern.Interface;
using SBSBillingSoftware.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Implementation
{
    public class OrderBusiness : IOrder
    {
        private readonly IGenericPattern<Order> _Order;
        private readonly IGenericPattern<Payment> _Payment;
        private readonly IGenericPattern<PaymentDetail> _PaymentDetail;

        private readonly IGenericPattern<OrderDetail> _OrderDetail;
        private readonly DateTime _createdOn;
        public OrderBusiness()
        {
            _Order = new GenericPattern<Order>();
            _OrderDetail = new GenericPattern<OrderDetail>();
            _createdOn = DateTime.Now;
            _Payment = new GenericPattern<Payment>();
            _PaymentDetail=new GenericPattern<PaymentDetail>();
        }

        public long  SavePayment(OrderModel model)
        {
          
            PaymentModel obj = new PaymentModel();
            obj.OrderId = model.ID;
            obj.CustomerId = model.CustomerID;
            obj.TotalAmount = model.TotalPrice;
            obj.BalanceAmount = model.Balance;
            obj.PaidAmount = model.AmountPaid;
            obj.PaymentDate = model.PaymentDate;
            obj.CreatedDate = model.CreatedOn;
            obj.Status = model.Status;
            obj.PaymentModeId = model.PaymentModeId;
            obj.DepositToId = model.DepositToId;
            obj.Amount = model.GrandTotal;
            obj.PaymentDetailsId = model.PaymentDetailsId;
            Payment model1 = new Payment(obj);

            if (model1!=null)
            {
                _Payment.Insert(model1);
            }

            return model1.Id;
        }

        public int SavePaymentDetails(OrderModel model)
        {
            PaymentModel obj = new PaymentModel();
            obj.OrderId = model.ID;
            obj.CustomerId = model.CustomerID;
            obj.TotalAmount = model.TotalPrice;
            obj.BalanceAmount = model.Balance;
            obj.PaidAmount = model.AmountPaid;
            obj.PaymentDate = model.PaymentDate;
            obj.CreatedDate = model.CreatedOn;
            obj.Status = model.Status;
            obj.PaymentModeId = model.PaymentModeId;
            obj.DepositToId = model.DepositToId;
            obj.Amount = model.GrandTotal;
            obj.Remark = model.Remark;
            PaymentDetail _paymentDetail = new PaymentDetail(obj);
            var payment = _PaymentDetail.Insert(_paymentDetail);
           return payment.Id;
        }
        public long UpdatePayment(OrderModel model)
        {

            Order obj = new Order(model);

            if (obj!=null)
            {
                var order = _Order.GetById(model.ID);
                order.Status = obj.Status;
                //var BalanceAmount = model.Balance;

                //order.AmountPaid = model.AmountPaid;
                _Order.Upate(order);
            }

            return obj.ID;

            
        }

        public List<BillingModel> CategoryList()
        {
            throw new NotImplementedException();
        }

        public OrderModel Getbyid(int id)
        {
            var res = _Order.GetById(id);
            OrderModel obj = new OrderModel();
            obj.ID =Convert.ToInt32( res.ID);
            obj.CustomerID = res.CustomerID;
            obj.ActualPrice = res.ActualPrice;
            obj.Discount = res.Discount;
            obj.TotalPrice = res.TotalPrice;
            //obj.Balance = res.Balance;
            //obj.AmountPaid = res.AmountPaid;
            obj.Status = res.Status;
            obj.CreatedOn = res.CreatedOn;
            obj.PaymentDate = res.PaymentDate;
            obj.CreatedBy = res.CreatedBy;
            return obj;
        }

        public BillingModel GetCategoryDetails(BillingModel model)
        {
            throw new NotImplementedException();
        }

        public long SaveOrder(BillingModel model)
        {
            //1. Insert into Order table
            //2. Insert into OrderDetails table with OrderId as foreingn key
            Order _order = new Order(model, _createdOn);
            try
            {
                _order.OrderDetails = new List<OrderDetail>();

                foreach (var item in model.BillingList)
                {
                    OrderDetail _orderDetail = new OrderDetail(item);
                    _orderDetail.OrderID = 1;
                    _order.OrderDetails.Add(_orderDetail);
                }
                _Order.Insert(_order);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _order.ID;
        }

        public BillingModel GetOrderList(BillingModel model)
        {
            BillingModel _billingModel= new BillingModel();
            _billingModel.OrderList = new List<BillingModel>();
            var orderList = _Order.GetAll();
            if (orderList!=null && orderList.Any())
            {
                _billingModel.OrderList = (from @item in orderList select new BillingModel {
                    OrderId = (Int32)@item.ID,
                    InvoiceNumber = CommonHelp.GenerateInvoiceNumber(@item.ID),
                    InvoiceDate = @item.CreatedOn ?? DateTime.Now,
                    CustomerName = @item.Customer != null ? @item.Customer.CustomerName : string.Empty,
                    Discount=@item.Discount,
                    GrandTotal=@item.TotalPrice
                }).ToList();
            }
            return _billingModel;
        }

        public OrderModel OrderList()
        {
            OrderModel _OrderModel = new OrderModel();
            _OrderModel.OrderList = new List<OrderModel>();
            var orderList = _Order.GetAll();
            DateTime obj;
            if (orderList != null && orderList.Any())
            {
                _OrderModel.OrderList = (from @item in orderList
                                         select new OrderModel
                                         {

                                             InvoiceNumber = Invoice.INV.ToString() + @item.ID,
                                             InvoiceDate = @item.CreatedOn ?? DateTime.Now,
                                             CustomerName = @item.Customer != null ? @item.Customer.CustomerName : string.Empty,
                                             Discount = Convert.ToDecimal(@item.Discount),
                                             GrandTotal = Convert.ToDecimal(@item.TotalPrice),
                                             Balance= (@item.Payments != null && @item.Payments.Any()) ? @item.Payments.OrderByDescending(m => m.Id).FirstOrDefault().BalanceAmount : @item.TotalPrice//Convert.ToDecimal(@item.Balance)

                                         }).ToList();
            }
            return _OrderModel;
        }

        public List<OrderModel> OrderLists()
        {
           List<OrderModel> _OrderModel = new List<OrderModel>();
           
            var orderList = _Order.GetAll();
            DateTime obj;
            if (orderList != null && orderList.Any())
            {
                _OrderModel = (from @item in orderList
                                         select new OrderModel
                                         {
                                             ID=Convert.ToInt32(item.ID),
                                             InvoiceNumber = Invoice.INV.ToString() + @item.ID,
                                             InvoiceDate = @item.CreatedOn ?? DateTime.Now,
                                             CustomerName = @item.Customer != null ? @item.Customer.CustomerName : string.Empty,
                                             Discount = Convert.ToDecimal(@item.Discount),
                                             GrandTotal = Convert.ToDecimal(@item.TotalPrice),
                                             Balance = (@item.Payments != null && @item.Payments.Any()) ? @item.Payments.OrderByDescending(m => m.Id).FirstOrDefault().BalanceAmount : @item.TotalPrice//Convert.ToDecimal(@item.Balance)

                                         }).ToList();
            }
            return _OrderModel;
        }
        public List<OrderModel> CustomerInvoiceList(int id, bool status=false)
        {
            IEnumerable<Order> orderList;
            if (status)
            {
                orderList = _Order.GetAll().Where(x => x.CustomerID == id);
            }
            else
            {
                orderList = _Order.GetAll().Where(x => x.CustomerID == id && x.Status == status);
            }
            List<OrderModel> _OrderModel = new List<OrderModel>();
            

            if (orderList != null && orderList.Any())
            {
                _OrderModel = (from @item in orderList
                               select new OrderModel
                               {
                                   ID = Convert.ToInt32(item.ID),
                                   InvoiceNumber = Invoice.INV.ToString() + @item.ID,
                                   stringDate = @item.CreatedOn.ToString(),
                                   InvoiceDate = @item.CreatedOn,
                                   CustomerName = @item.Customer != null ? @item.Customer.CustomerName : string.Empty,
                                   TotalPrice = Convert.ToDecimal(@item.TotalPrice),
                                   Discount = Convert.ToDecimal(@item.Discount),
                                   GrandTotal = Convert.ToDecimal(@item.TotalPrice),
                                   Balance = (@item.Payments != null && @item.Payments.Any()) ? @item.Payments.OrderByDescending(m => m.Id).FirstOrDefault().BalanceAmount : @item.TotalPrice,//Convert.ToDecimal(@item.Balance)
                                   AmountPaid = (@item.Payments != null && @item.Payments.Any()) ? @item.Payments.OrderByDescending(m => m.Id).FirstOrDefault().PaidAmount : 0,
                                   PaymentList = (from @itemPaymentList in @item.Payments select new PaymentModel {
                                       Id= @itemPaymentList.Id,
                                       OrderId= @itemPaymentList.OrderId,
                                       TotalAmount= @itemPaymentList.TotalAmount,
                                       PaidAmount= @itemPaymentList.PaidAmount,
                                       BalanceAmount= @itemPaymentList.BalanceAmount,
                                       CreatedDate= @itemPaymentList.CreatedDate
                                   }).ToList()
                               }).ToList();
            }
            return _OrderModel;
        }

        public PaymentModel GetPaymentReceiptBy(PaymentModel paymentModel)
        {
            PaymentModel _PaymentModel = new PaymentModel();
           PaymentDetail paymentDetails = _PaymentDetail.GetById(paymentModel.Id);
            _PaymentModel.Amount = paymentDetails.Amount;
            DateTime paymentdate= Convert.ToDateTime(paymentDetails.PaymentDate);
            _PaymentModel.DisplayPaymentDate =paymentdate.ToShortDateString();
          //  _PaymentModel.PaymentModeId = paymentDetails.PaymentModeId;
            _PaymentModel.PaymentMadeName = paymentDetails.PaymentMode.Name;
            _PaymentModel.NameCustomer=paymentDetails.Payments.FirstOrDefault().Order.Customer.CustomerName;
           // _PaymentModel.PaymentMadeName=paymentDetails.p
            if (paymentDetails.Payments!=null && paymentDetails.Payments.Any())
            {
                _PaymentModel.paymentList = (from @itemPayment in paymentDetails.Payments
                                             select new PaymentModel
                                             {
                                                 OrderId = @itemPayment.OrderId,
                                                 PaymentDate = @itemPayment.CreatedDate,
                                                 TotalAmount = @itemPayment.Order.TotalPrice,
                                                 PaidAmount = @itemPayment.PaidAmount,
                                                 BalanceAmount = @itemPayment.BalanceAmount,
                                                 Status = @itemPayment.Status,
                                                 NameCustomer = @itemPayment.Order.Customer.CustomerName,
                                                 InvoiceDate=@itemPayment.Order.CreatedOn,
                                                 CreatedDate= @itemPayment.Order.PaymentDate,
                                                 
                                             }
                                             ).ToList();
            }
            return _PaymentModel;
        }

        public List<OrderModel> orderlist()
        {
            List<OrderModel> _orderList = new List<OrderModel>();
            var CategoryList = _Order.GetAll().ToList();
            _orderList = (from item in CategoryList
                          select new OrderModel
                          {
                              OrderID = item.ID,
                          }).OrderByDescending(x => x.OrderID).ToList();
            return _orderList;
        }
    }
}
