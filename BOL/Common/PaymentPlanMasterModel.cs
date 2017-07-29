using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Common
{
    public class PaymentPlanMasterModel
    {
            public int Id { get; set; }

            public string Name { get; set; }

            public int? Months { get; set; }

            public DateTime? CreatedDate { get; set; }

            public bool? Status { get; set; }

        public List<PaymentPlanMasterModel> PaymentPlanMasterLists { get; set; }
    }
}
