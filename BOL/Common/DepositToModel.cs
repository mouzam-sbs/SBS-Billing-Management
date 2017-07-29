using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Common
{
    public class DepositToModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CreatedDate { get; set; }

        public List<DepositToModel> DepositToList { get; set; }
    }
}
