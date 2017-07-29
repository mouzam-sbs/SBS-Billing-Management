using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Common
{
  public  class PaymentTransactionModel
    {
        public int Id { get; set; }

        public int? CustomerId { get; set; }

        public string CustomerName { get; set; }

        public DateTime? PaymentDate { get; set; }

        public int? PaymentModeId { get; set; }

        public int? DepositToId { get; set; }

        public decimal? Amount { get; set; }

        public string Remarks { get; set; }

        public DateTime? CreatedDate { get; set; }
 

        public List<PaymentModel> Payments { get; set; }


        public List<CustomerModel> CustomerModelList { get; set; }

        public List<DepositToModel> DepositTo { get; set; }

        public List<OrderModel> Order { get; set; }

        public List<PaymentModeModel> PaymentMode { get; set; }
        public List<PaymentTransactionModel> PaymentTransactionModelList { get; set; }

    }
}
