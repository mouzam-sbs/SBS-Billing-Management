using BOL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IOrder
    {
        BillingModel GetCategoryDetails(BillingModel model);
        List<BillingModel> CategoryList();
        long SaveOrder(BillingModel mode);
        OrderModel Getbyid(int id);
        BillingModel GetOrderList(BillingModel model);
        OrderModel OrderList();
        List<OrderModel> CustomerInvoiceList(int id,bool status=false);
        long SavePayment(OrderModel model);
        long UpdatePayment(OrderModel model); 
        int SavePaymentDetails(OrderModel model);
        PaymentModel GetPaymentReceiptBy(PaymentModel paymentModel);
        List<OrderModel> OrderLists();
        List<OrderModel> orderlist();

    }
    }
 