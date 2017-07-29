using BOL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
  public  interface IDepositTo
    {
        DepositToModel GetDepositToDetails(DepositToModel model);
        List<DepositToModel> DepositToList();
        int SaveDepositTo(DepositToModel mode);
        DepositToModel Getbyid(int id);
    }
}
