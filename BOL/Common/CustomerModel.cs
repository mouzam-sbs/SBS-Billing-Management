using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Common
{
    public class CustomerModel
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public string AlternateMobile { get; set; }

        public string Address { get; set; }

        public string Remark { get; set; }

        public byte[] ProfilePic1 { get; set; }

        public byte[] AttachmentPic1 { get; set; }

        public byte[] AttachmentPic2 { get; set; }

        public byte[] AttachmentPic3 { get; set; }

        public byte[] IdProofPic4 { get; set; }
        public List<OrderModel> OrderList { get; set; }

        public List<CustomerModel> CustomerModelList { get; set; }

    }
}
