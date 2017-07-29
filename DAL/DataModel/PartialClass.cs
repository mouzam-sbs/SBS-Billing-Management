using BOL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataModel
{
    public class PartialClass
    {
    }

    public partial class Category
    {
        public Category(CategoryModel _obj)
        {
            ID = _obj.CategoryId;
            CategoryName = _obj.CategoryName;
            ParentID = _obj.ParentId;
            CreatedBy = 1;
            CreatedOn = DateTime.Now;
        }
    }

    public partial class Customer
    {

        public Customer(CustomerModel _obj)
        {
            ID = _obj.ID;
            CustomerName = _obj.CustomerName;
            Mobile = _obj.Mobile;
            Email = _obj.Email;
            DOB = Convert.ToDateTime(_obj.DOB);
            AlternateNumber = _obj.AlternateMobile;
            Address = _obj.Address;
            Remark = _obj.Remark;
            ProfilePic1 = _obj.ProfilePic1;
            AttachmentPic1 = _obj.AttachmentPic1;
            AttachmentPic2 = _obj.AttachmentPic2;
            AttachmentPic3 = _obj.AttachmentPic3;
            IdProofPic4 = _obj.IdProofPic4;
        }
    }

    public partial class Product
    {

        public Product(ProductModel _obj)
        {
            ID = _obj.ID;
            ProductName = _obj.ProductName;
            CategoryId = _obj.CategoryId;
            Description = _obj.Description;
            Price = _obj.Price;
            Image = _obj.Image;
            ImageType = _obj.ImageType;
            CreatedBy = 1;
            CreatedOn = DateTime.Now;
            UpdatedBy = 1;
            UpdatedOn = DateTime.Now;
        }
    }

    public partial class PaymentPlanMaster
    {
        public PaymentPlanMaster(PaymentPlanMasterModel _obj)
        {
            Id = _obj.Id;
            Name = _obj.Name;
            CreatedDate = _obj.CreatedDate;
            Months = _obj.Months;
            Status = _obj.Status;
        }
    }
    public partial class AssignCustomer
    {
        public AssignCustomer()
        {

        }
        public AssignCustomer(AssignCustomerModel obj)
        {
            Id = obj.Id;
            CustomerId = obj.CustomerId;
            UserId = obj.UserId;
            CreatedDate = obj.CreatedDate;
            CreatedBy = CreatedBy;
        }
    }


    public partial class CustomerPaymentPlan
    {
        
        public CustomerPaymentPlan(CustomerPaymentPlanModel _obj)
        {
            Id = _obj.Id;
            PlanId = _obj.PlanId;
            InvoiceId = _obj.InvoiceId;
            AmountPerMonth = _obj.AmountPerMonth;
            CustomerId = _obj.CustomerId;
            Notes = _obj.Notes;
            StartDate = _obj.StartDate;
            CreatedDate = _obj.CreatedDate;
        }
    }

    public partial class Order
    {
        public Order(BillingModel _obj, DateTime _createdDate)
        {
            ID = _obj.OrderId;
            TransactionID = _obj.TransactionId;
            CustomerID = _obj.CustomerId;
            ActualPrice = _obj.SubTotal;
            Discount = _obj.Discount;
            //Balance = _obj.BalanceAmount;
            //AmountPaid = _obj.PaidAmount;
            Status = _obj.Status; ;
            PaymentDate = _obj.PaymentDate;
            Adjustment = _obj.Adjustment;
            TotalPrice = _obj.GrandTotal;
            CreatedOn = _createdDate;

            //CreatedBy = _userId;
        }
        public Order(OrderModel _obj)
        {
            ID = _obj.ID;

            CustomerID = _obj.CustomerID;
            ActualPrice = _obj.ActualPrice;
            Discount = _obj.TotalDiscount;
            Adjustment = _obj.Adjustment;
            TotalPrice = _obj.GrandTotal;
            PaymentDate = _obj.PaymentDate;
            //Balance = _obj.Balance;
            //AmountPaid = _obj.AmountPaid;
            Status = _obj.Status;
            CreatedOn = CreatedOn;
        }

        public Order(BillingModel _obj, DateTime _createdDate, int _userId)
        {
            ID = _obj.OrderId;
            TransactionID = _obj.TransactionId;
            CustomerID = _obj.CustomerId;
            ActualPrice = _obj.SubTotal;
            Discount = _obj.Discount;
            Adjustment = _obj.Adjustment;
            TotalPrice = _obj.GrandTotal;
            CreatedOn = _createdDate;
            CreatedBy = _userId;
        }
    }


    public partial class OrderDetail
    {


        public OrderDetail(BillingModel _obj)
        {
            ID = _obj.OrderDetailsId;
            OrderID = _obj.OrderId;
            ProductID = _obj.ProductNameId;
            Quantity = _obj.ProductQuantity;
            UnitPrice = _obj.ProductPrice;
            TotalPrice = _obj.ProductAmount;
            Discount = _obj.ProductDiscount;
        }
    }

    public partial class Payment
    {


        public Payment()
        {

        }

        public Payment(PaymentModel obj)
        {
            Id = obj.Id;
            OrderId = obj.OrderId;
            TotalAmount = obj.TotalAmount;
            BalanceAmount = obj.BalanceAmount;
            PaidAmount = obj.PaidAmount;
            CreatedDate = obj.CreatedDate;
            CustomerId = obj.CustomerId;
            Status = obj.Status;
            PaymentDetailsId = obj.PaymentDetailsId;
        }

    }

    public partial class PaymentTransaction
    {


        public PaymentTransaction()
        {

        }

        public PaymentTransaction(PaymentTransactionModel obj)
        {
            //Id = obj.Id;
            //CustomerId = obj.CustomerId;
            //PaymentModeId = obj.PaymentModeId;
            //DepositToId = obj.DepositToId;
            //Amount = obj.Amount;
            //PaymentDate = obj.PaymentDate;
            //Remarks = obj.Remarks;
            //CreatedDate = obj.CreatedDate;

        }

    }
    public partial class PaymentDetail
    {
        public PaymentDetail(PaymentModel obj)
        {
            Amount = obj.Amount;
            PaymentDate = obj.PaymentDate;
            PaymentModeId = obj.PaymentModeId;
            DepositToId = obj.DepositToId;
            CreatedDate = obj.CreatedDate;
            Remark = obj.Remark;
        }
    }
}
