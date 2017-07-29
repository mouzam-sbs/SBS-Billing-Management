using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Common
{
   public class PaymentModel
    {
        public int Id { get; set; }

        public long? OrderId { get; set; }

        public decimal? Amount { get; set; }

        public decimal? TotalAmount { get; set; }

        public decimal? PaidAmount { get; set; }

        public decimal? BalanceAmount { get; set; }

        public string PaymentMadeName { get; set; }

        public int? CustomerId { get; set; }

        public int PaymentModeId { get; set; }

        public string  DisplayPaymentDate { get; set; }

        public int DepositToId { get; set; }

        public string NameCustomer { get; set; }

        public int? TransactionId { get; set; }

        public int PaymentDetailsId { get; set; }

        public DateTime? InvoiceDate { get; set; }

        public string Remark { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? PaymentDate { get; set; }

        public bool? Status { get; set; }

        public CustomerModel Customer { get; set; }

        public OrderModel  Order { get; set; }               

        public List<CustomerModel> CustomerModelList { get; set; }

        public List<OrderModel> OrderList { get; set; }

        public List<PaymentModel> paymentList { get; set; }

        public List<PaymentModeModel> PaymentModeList { get; set; }

        public List<DepositToModel> DeopsitToList { get; set; }

    }
}
