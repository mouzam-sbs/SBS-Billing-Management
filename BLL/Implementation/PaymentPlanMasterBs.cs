using BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL.Common;
using DAL.DataModel;
using DAL.GenericPattern.Interface;
using DAL.GenericPattern.Implementation;

namespace BLL.Implementation
{
    public class PaymentPlanMasterBs : IPaymentPlanMaster
    {
        private readonly IGenericPattern<PaymentPlanMaster> tbl_PaymentPlanMaster;

        public PaymentPlanMasterBs()
        {
            tbl_PaymentPlanMaster = new GenericPattern<PaymentPlanMaster>();

        }

        public PaymentPlanMasterModel GetById(int id)
        {
            PaymentPlanMasterModel _PaymentPlanMasterModel = new PaymentPlanMasterModel();
            var item = tbl_PaymentPlanMaster.GetById(id);
            _PaymentPlanMasterModel = new PaymentPlanMasterModel
            {

                Id = item.Id,
                Name = item.Name,
                Months = item.Months,
                CreatedDate = item.CreatedDate,
                Status = item.Status,
            };
            return _PaymentPlanMasterModel;
        }

        public PaymentPlanMasterModel GetDetails(PaymentPlanMasterModel model)
        {
            model = model ?? new PaymentPlanMasterModel();
            if (model.Id != 0)
            {
                model.PaymentPlanMasterLists = PaymentPlanMasterList();

            }
            model.PaymentPlanMasterLists = PaymentPlanMasterList();

            return model;
        }

        public List<PaymentPlanMasterModel> PaymentPlanMasterList()
        {
            List<PaymentPlanMasterModel> _PaymentPlanMasterModel = new List<PaymentPlanMasterModel>();
            var Vardata = tbl_PaymentPlanMaster.GetAll().ToList();
            _PaymentPlanMasterModel = (from item in Vardata
                                 select new PaymentPlanMasterModel
                                 {
                                     Id = item.Id,
                                     Name = item.Name,
                                     Months=item.Months,
                                     CreatedDate=item.CreatedDate,
                                     Status=item.Status,

                                 }).OrderByDescending(x => x.Id).ToList();
            return _PaymentPlanMasterModel;
        }

        public int Save(PaymentPlanMasterModel model)
        {
            PaymentPlanMaster _paymentplanmaster = new PaymentPlanMaster(model);
            if (model.Id != null && model.Id != 0)
            {
                tbl_PaymentPlanMaster.Upate(_paymentplanmaster);

            }
            else
            {

                tbl_PaymentPlanMaster.Insert(_paymentplanmaster);
            }

            return _paymentplanmaster.Id;
        }
    }
}
