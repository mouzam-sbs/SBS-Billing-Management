using BOL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IPaymentPlanMaster
    {
        List<PaymentPlanMasterModel> PaymentPlanMasterList();

        PaymentPlanMasterModel GetDetails(PaymentPlanMasterModel model);

        int Save(PaymentPlanMasterModel model);

        PaymentPlanMasterModel GetById(int id);
    }
}
