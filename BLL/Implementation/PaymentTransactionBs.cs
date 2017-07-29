using BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL.Common;
using DAL.GenericPattern.Interface;
using DAL.GenericPattern.Implementation;
using DAL.DataModel;

namespace BLL.Implementation
{
    public class PaymentTransactionBs// : IPaymentTransaction
    {
        //private readonly IGenericPattern<PaymentTransaction> _PaymentTran;
        //private readonly IGenericPattern<Customer> _customer;

        //public PaymentTransactionBs()
        //{
        //    _PaymentTran = new GenericPattern<PaymentTransaction>();
        //    _customer = new GenericPattern<Customer>();
        //}

        //public List<CustomerModel> CustomerList()
        //{
        //    GenericPattern<Customer> _customer = new GenericPattern<Customer>();
        //    List<CustomerModel> _customerList = new List<CustomerModel>();
        //    var cusData = _customer.GetAll().ToList();
        //    _customerList = (from item in cusData
        //                 select new CustomerModel
        //                 {
        //                     ID = item.ID,
        //                     CustomerName = item.CustomerName

        //                 }).OrderByDescending(x => x.ID).ToList();
        //    return _customerList;
        //}

        ////public PaymentTransactionModel GetbyId(int id)
        ////{
        ////    PaymentTransactionModel _trans = new PaymentTransactionModel();
        ////    var item = _PaymentTran.GetById(id);
        ////    item = item ?? new PaymentTransaction();
        ////    _trans = new PaymentTransactionModel
        ////    {
        ////        Id = item.Id,
        ////        CustomerId = item.CustomerId,
        ////        CustomerName = item.Customer.CustomerName,
        ////        PaymentDate = item.PaymentDate,
        ////        PaymentModeId = item.PaymentModeId,
        ////        DepositToId = item.DepositToId,
        ////        Amount = item.Amount,
        ////        Remarks = item.Remarks,
        ////        CreatedDate = item.CreatedDate,
        ////    };
        ////    return _trans;
        ////}

        //public PaymentTransactionModel GetPaymentTransactionDetails(PaymentTransactionModel model)
        //{
        //    model = model ?? new PaymentTransactionModel();
        //    if (model.Id != 0)
        //    {
        //        model.PaymentTransactionModelList = PaymentTransactionList();
        //        model.CustomerModelList = CustomerList();
        //    }
        //    model.PaymentTransactionModelList = PaymentTransactionList();

        //    return model;
        //}

        //public List<PaymentTransactionModel> PaymentTransactionList()
        //{
        //    List<PaymentTransactionModel> _transList = new List<PaymentTransactionModel>();
        //    var TransData = _PaymentTran.GetAll().ToList();
        //    _transList = (from item in TransData
        //                  select new PaymentTransactionModel
        //                  {
        //                      Id = item.Id,
        //                      CustomerId=item.CustomerId,
        //                      CustomerName=item.Customer.CustomerName,
        //                      PaymentDate=item.PaymentDate,
        //                      PaymentModeId=item.PaymentModeId,
        //                      DepositToId=item.DepositToId,
        //                      Amount=item.Amount,
        //                      Remarks=item.Remarks,
        //                      CreatedDate = item.CreatedDate,

        //                    }).OrderByDescending(x => x.Id).ToList();
        //    return _transList;
        //}

        //public int SavePaymentTransaction(PaymentTransactionModel model)
        //{
        //    PaymentTransaction obj = new PaymentTransaction(model);
        //    if (obj!=null && obj.Id!=0)
        //    {
        //        _PaymentTran.Upate(obj);
        //    }
        //    else
        //    {
        //        _PaymentTran.Insert(obj);
        //    }
        //    return obj.Id;
        //}
    }
}
