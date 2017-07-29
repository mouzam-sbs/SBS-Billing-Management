namespace DAL.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            AssignCustomers = new HashSet<AssignCustomer>();
            CustomerPaymentPlans = new HashSet<CustomerPaymentPlan>();
            Orders = new HashSet<Order>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string CustomerName { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public DateTime? DOB { get; set; }

        [StringLength(50)]
        public string AlternateNumber { get; set; }

        [StringLength(150)]
        public string Remark { get; set; }

        public string Address { get; set; }

        public byte[] ProfilePic1 { get; set; }

        public byte[] IdProofPic4 { get; set; }

        public byte[] AttachmentPic1 { get; set; }

        public byte[] AttachmentPic2 { get; set; }

        public byte[] AttachmentPic3 { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssignCustomer> AssignCustomers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerPaymentPlan> CustomerPaymentPlans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
