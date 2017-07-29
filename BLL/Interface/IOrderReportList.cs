using BOL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
   public interface IOrderReportList
    {
        List<OrderReports> OrderDetailsList();
        List<OrderReports> OrderDetailsLists();
    }
}
