using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BOL.Common
{
 public class AssignCustomerModel
    {
        public int Id { get; set; }

        public int? CustomerId { get; set; }

        public int? UserId { get; set; }
     
        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public  List<CustomerModel> CustomerList { get; set; }

        public IEnumerable<SelectListItem> CustomerList1 { get; set; }
        public IEnumerable<SelectListItem> CustomerList2 { get; set; }

        public IEnumerable<int> SelectedCustomers { get; set; }

        public List<UserDetails> UserList { get; set; }

    }
}
