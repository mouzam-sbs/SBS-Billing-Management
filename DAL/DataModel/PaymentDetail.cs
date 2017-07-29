namespace DAL.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PaymentDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PaymentDetail()
        {
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }

        public decimal? Amount { get; set; }

        public DateTime? PaymentDate { get; set; }

        public int? PaymentModeId { get; set; }

        public int? DepositToId { get; set; }

        [StringLength(100)]
        public string Remark { get; set; }

        public DateTime? CreatedDate { get; set; }

        public virtual DepositTo DepositTo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }

        public virtual PaymentMode PaymentMode { get; set; }
    }
}
