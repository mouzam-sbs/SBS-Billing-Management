using BLL.Interface;
using DAL.DataModel;
using DAL.GenericPattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL.Common;
using DAL.GenericPattern.Implementation;
using BOL.Helpers;
using SBSBillingSoftware.Helpers;

namespace BLL.Implementation
{
    public class CustomerPaymentPlanBs : ICustomerPaymentPlan
    {
        private readonly IGenericPattern<CustomerPaymentPlan> tbl_CustomerPaymentPlan;

        public CustomerPaymentPlanBs()
        {
            tbl_CustomerPaymentPlan = new GenericPattern<CustomerPaymentPlan>();

        }

        public List<CustomerModel> CustomerList()
        {
            GenericPattern<Customer> _tblCustomer = new GenericPattern<Customer>();
            List<CustomerModel> _CustomerList = new List<CustomerModel>();
            var VarData = _tblCustomer.GetAll().ToList();
            _CustomerList = (from item in VarData
                             select new CustomerModel
                             {
                             ID = item.ID,
                             CustomerName = item.CustomerName

                         }).OrderByDescending(x => x.ID).ToList();
            return _CustomerList;
        }

        public List<CustomerPaymentPlanModel> CustomerPaymentPlanList()
        {
            List<CustomerPaymentPlanModel> _CustomerPaymentPlanModel = new List<CustomerPaymentPlanModel>();
            var Vardata = tbl_CustomerPaymentPlan.GetAll().ToList();
            _CustomerPaymentPlanModel = (from item in Vardata
                                 select new CustomerPaymentPlanModel
                                 {
                                     Id = item.Id,
                                     PlanId=item.PlanId,
                                     Name = item.PaymentPlanMaster.Name,
                                     InvoiceId = item.InvoiceId,
                                     Invoice=item.Order.ID.ToString(),
                                   //  InvoiceAmount=item.InvoiceAmount,
                                    // AmountPerMonth=item.AmountPerMonth,
                                     CustomerId =item.CustomerId,
                                   //  Months=item.Months,
                                     Notes=item.Notes,
                                     StartDate=item.StartDate,
                                    // EndDate=item.EndDate,
                                     CreatedDate=item.CreatedDate

                                 }).OrderByDescending(x => x.Id).ToList();
            return _CustomerPaymentPlanModel;
        }

        public CustomerPaymentPlanModel GetById(int id)
        {
            CustomerPaymentPlanModel _CustomerPaymentPlanModel = new CustomerPaymentPlanModel();
            var item = tbl_CustomerPaymentPlan.GetById(id);
            _CustomerPaymentPlanModel = new CustomerPaymentPlanModel
            {

                Id = item.Id,
                PlanId = item.PlanId,
                Name=item.PaymentPlanMaster.Name,
                InvoiceId = item.InvoiceId,
                Invoice = item.Order.ID.ToString(),
              //  InvoiceAmount = item.InvoiceAmount,
              //  AmountPerMonth = item.AmountPerMonth,
                CustomerId = item.CustomerId,
             //   Months = item.Months,
                Notes = item.Notes,
                StartDate = item.StartDate,
             //   EndDate = item.EndDate,
                CreatedDate = item.CreatedDate

            };
            return _CustomerPaymentPlanModel;
        }

        public CustomerPaymentPlanModel GetDetails(CustomerPaymentPlanModel model)
        {
            model = model ?? new CustomerPaymentPlanModel();
            if (model.Id != 0)
            {
                model.CustomerPaymentPlanLists = CustomerPaymentPlanList();
                model.CustomerModelList = CustomerList();
                model.OrderList = OrderList();
                model.PaymentPlanMasterLists = PaymentPlanMasterList();


            }
            model.CustomerPaymentPlanLists = CustomerPaymentPlanList();

            return model;
        }

        public List<OrderModel> OrderList()
        {
            GenericPattern<Order> _tblOrder = new GenericPattern<Order>();
            List<OrderModel> _OrderList = new List<OrderModel>();
            var VarData = _tblOrder.GetAll().ToList();
            _OrderList = (from item in VarData
                          select new OrderModel
                          {
                              ID = (int)item.ID,
                              InvoiceNumber = CommonHelp.GenerateInvoiceNumber(item.ID)

                             }).OrderByDescending(x => x.ID).ToList();
            return _OrderList;
        }

        public List<PaymentPlanMasterModel> PaymentPlanMasterList()
        {
            GenericPattern<PaymentPlanMaster> _tblPaymentPlanMaster = new GenericPattern<PaymentPlanMaster>();
            List<PaymentPlanMasterModel> _PaymentPlanMasterList = new List<PaymentPlanMasterModel>();
            var VarData = _tblPaymentPlanMaster.GetAll().ToList();
            _PaymentPlanMasterList = (from item in VarData
                             select new PaymentPlanMasterModel
                             {
                                 Id = item.Id,
                                 Name=item.Name,
                            //     Months = item.Months
                                 

                             }).OrderByDescending(x => x.Id).ToList();
            return _PaymentPlanMasterList;
        }

        public int Save(CustomerPaymentPlanModel model)
        {
            CustomerPaymentPlan _CustomerPaymentPlan = new CustomerPaymentPlan(model);
            if (model.Id != null && model.Id != 0)
            {
                tbl_CustomerPaymentPlan.Upate(_CustomerPaymentPlan);

            }
            else
            {

                tbl_CustomerPaymentPlan.Insert(_CustomerPaymentPlan);
            }

            return _CustomerPaymentPlan.Id;
        }
    }
}
