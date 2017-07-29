using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Common
{
   public class PaymentModeModel
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string CreatedDate { get; set; }

        public List<PaymentModeModel> PaymentModeList { get; set; }
    }
}
