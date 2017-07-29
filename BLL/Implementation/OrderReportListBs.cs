using BLL.Interface;
using BOL.Common;
using DAL.DataModel;
using DAL.GenericPattern.Implementation;
using DAL.GenericPattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Implementation
{
    public class OrderReportListBs : IOrderReportList
    {
        private readonly IGenericPattern<Order> _Order;
        private readonly IGenericPattern<OrderDetail> _OrderDetail;
        public OrderReportListBs()
        {
            _Order = new GenericPattern<Order>();
            _OrderDetail = new GenericPattern<OrderDetail>();
        }


        public List<OrderReports> OrderDetailsList()
        {
            List<OrderReports> _OrderList = new List<OrderReports>();
            var _orderList = _Order.GetAll().ToList();
            _OrderList = (from item in _orderList
                          select new OrderReports
                          {
                              OrderId = unchecked((int)item.ID),
                              CustomerId = (Int32)item.CustomerID,
                              CustomerName = item.Customer.CustomerName,
                              ProductNameId = (Int32)item.OrderDetails.FirstOrDefault().ProductID,
                              ProductName = item.OrderDetails.FirstOrDefault().Product.ProductName,
                              ProductPrice = item.OrderDetails.FirstOrDefault().Product.Price,
                              ProductQuantity = item.OrderDetails.FirstOrDefault().Quantity,
                              Discount = Convert.ToDecimal(item.ActualPrice),
                              ActualPrice = Convert.ToDecimal(item.ActualPrice),
                              InvoiceDate = Convert.ToDateTime(item.CreatedOn)

                          }).ToList();

            return _OrderList;
        }


        public List<OrderReports> OrderDetailsLists()
        {
            List<OrderReports> _OrderList = new List<OrderReports>();
            var _orderList = _Order.GetAll().ToList();
            _OrderList = (from item in _orderList
                          select new OrderReports
                          {
                              OrderId = unchecked((int)item.ID),
                              CustomerId = (Int32)item.CustomerID,
                              CustomerName = item.Customer.CustomerName,
                              ProductNameId = (Int32)item.OrderDetails.FirstOrDefault().ProductID,
                              ProductName = item.OrderDetails.FirstOrDefault().Product.ProductName,
                              ProductPrice = item.OrderDetails.FirstOrDefault().Product.Price,
                              ProductQuantity = item.OrderDetails.FirstOrDefault().Quantity,
                              Discount = Convert.ToDecimal(item.ActualPrice),
                              ActualPrice = Convert.ToDecimal(item.ActualPrice),
                              InvoiceDate = Convert.ToDateTime(item.CreatedOn)

                          }).ToList();

            return _OrderList;
        }
    }
}
