namespace DAL.DataModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BillingEntities : DbContext
    {
        public BillingEntities()
            : base("name=BillingEntities")
        {
        }

        public virtual DbSet<AssignCustomer> AssignCustomers { get; set; }
        public virtual DbSet<BanquetAppointment> BanquetAppointments { get; set; }
        public virtual DbSet<BanquetHall> BanquetHalls { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerPaymentPlan> CustomerPaymentPlans { get; set; }
        public virtual DbSet<DepositTo> DepositToes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentAgreement> PaymentAgreements { get; set; }
        public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }
        public virtual DbSet<PaymentMode> PaymentModes { get; set; }
        public virtual DbSet<PaymentPlanMaster> PaymentPlanMasters { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SaveImage> SaveImages { get; set; }
        public virtual DbSet<ScheduleFollowup> ScheduleFollowups { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }
        public virtual DbSet<Worklog> Worklogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BanquetAppointment>()
                .Property(e => e.EventTitle)
                .IsUnicode(false);

            modelBuilder.Entity<BanquetAppointment>()
                .Property(e => e.EventDesc)
                .IsUnicode(false);

            modelBuilder.Entity<BanquetHall>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CustomerName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.AlternateNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<CustomerPaymentPlan>()
                .Property(e => e.AmountPerMonth)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CustomerPaymentPlan>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<CustomerPaymentPlan>()
                .HasMany(e => e.PaymentAgreements)
                .WithRequired(e => e.CustomerPaymentPlan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DepositTo>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<DepositTo>()
                .Property(e => e.CreatedDate)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .HasMany(e => e.CustomerPaymentPlans)
                .WithOptional(e => e.Order)
                .HasForeignKey(e => e.InvoiceId);

            modelBuilder.Entity<Payment>()
                .Property(e => e.TotalAmount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Payment>()
                .Property(e => e.PaidAmount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Payment>()
                .Property(e => e.BalanceAmount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PaymentDetail>()
                .Property(e => e.Amount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PaymentDetail>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<PaymentDetail>()
                .HasMany(e => e.Payments)
                .WithOptional(e => e.PaymentDetail)
                .HasForeignKey(e => e.PaymentDetailsId);

            modelBuilder.Entity<PaymentMode>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<PaymentPlanMaster>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<PaymentPlanMaster>()
                .HasMany(e => e.CustomerPaymentPlans)
                .WithOptional(e => e.PaymentPlanMaster)
                .HasForeignKey(e => e.PlanId);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ImageType)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<SaveImage>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<SaveImage>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<SaveImage>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<ScheduleFollowup>()
                .Property(e => e.OutComes)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Salt)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Hash)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<UserType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Worklog>()
                .Property(e => e.Purpose)
                .IsUnicode(false);

            modelBuilder.Entity<Worklog>()
                .Property(e => e.FoolowUpNotes)
                .IsUnicode(false);
        }
    }
}
