using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Common
{
    public class CustomerPaymentPlanModel
    {
        public int Id { get; set; }

        public int? PlanId { get; set; }
        public string Name { get; set; }

        public long? InvoiceId { get; set; }
        public string Invoice { get; set; }

        public DateTime? StartDate { get; set; }

        public string Notes { get; set; }

        public DateTime? CreatedDate { get; set; }

        public decimal? InvoiceAmount { get; set; }

        public int? CustomerId { get; set; }

        public DateTime? EndDate { get; set; }

        public int Months { get; set; }

        public double AmountPerMonth { get; set; }

        public List<CustomerPaymentPlanModel> CustomerPaymentPlanLists { get; set; }
        public List<PaymentPlanMasterModel> PaymentPlanMasterLists { get; set; }
        public List<CustomerModel> CustomerModelList { get; set; }
        public List<OrderModel> OrderList { get; set; }

    }
}
