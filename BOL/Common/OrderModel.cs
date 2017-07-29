using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Common
{
  public  class OrderModel
    {
        public int ID { get; set; }

        public int? CreatedBy { get; set; }

        public int? CustomerID { get; set; }

        public string CustomerName { get; set; }

        public int ProductID { get; set; }

        public int? Adjustment { get; set; }

        public string TransactionID { get; set; }

        public decimal? ActualPrice { get; set; }  

        public int? TotalDiscount { get; set; }
        public int PaymentDetailsId { get; set; }
        public string Remark { get; set; }

        public decimal? DiscountActual { get; set; }

        public decimal? GrandTotal { get; set; }

        public decimal? Discount { get; set; }

        public decimal? TotalPrice { get; set; }

        public long OrderID { get; set; }

        public int Quantity { get; set; }

        public int PaymentModeId { get; set; }

        public int DepositToId { get; set; }

        public decimal? UnitPrice { get; set; }

        public string InvoiceNumber { get; set; }

        public DateTime? CreatedOn { get; set; }

        public decimal? AmountPaid { get; set; }

        public decimal? Balance { get; set; }

        public bool? Status { get; set; }

        public decimal? Totalbalance { get; set; }

        public string stringDate { get; set;}

        public DateTime? InvoiceDate { get; set; }

        public DateTime? PaymentDate { get; set; }

        public List<OrderModel> OrderList { get; set; }

        public List<PaymentModel> PaymentList { get; set; }

        public string htmlToPdf { get; set; }

        public string pdfFileName { get; set; }
    }
}
