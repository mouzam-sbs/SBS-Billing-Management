namespace DAL.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerPaymentPlan")]
    public partial class CustomerPaymentPlan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerPaymentPlan()
        {
            PaymentAgreements = new HashSet<PaymentAgreement>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? PlanId { get; set; }

        public int? CustomerId { get; set; }

        public long? InvoiceId { get; set; }

        public int? Months { get; set; }

        public decimal? AmountPerMonth { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [StringLength(250)]
        public string Notes { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Order Order { get; set; }

        public virtual PaymentPlanMaster PaymentPlanMaster { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentAgreement> PaymentAgreements { get; set; }
    }
}
