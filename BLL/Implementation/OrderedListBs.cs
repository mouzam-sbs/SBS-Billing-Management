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
    public class OrderedListBs : IOrderedList
    {
        private readonly IGenericPattern<Order> _Order;
        private readonly IGenericPattern<OrderDetail> _OrderDetail;

        public OrderedListBs()
        {
            _Order = new GenericPattern<Order>();
            _OrderDetail = new GenericPattern<OrderDetail>();
        }

        public List<OrderReports> OrderDetailsLists()
        {
            List<OrderReports> _OrderList = new List<OrderReports>();
            _OrderList = _OrderList?? new List<OrderReports>();
            var _orderList = _OrderDetail.GetAll().ToList();
            StringBuilder query = new StringBuilder();
            query.Append("select C.CategoryName, O.ID,O.ActualPrice,O.Discount,O.TotalPrice,P.ProductName,OD.Quantity from [Order] as O inner join OrderDetails as OD on O.ID=OD.OrderID  INNER JOIN Product AS P ON OD.ProductID=P.ID INNER JOIN Category AS c ON P.CategoryId=c.ID");
            

            var res = _Order.GetMultipleTablesDataById(query.ToString()).ToList();
            
            return _OrderList;

        }
    }
}
