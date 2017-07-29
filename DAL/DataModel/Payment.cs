namespace DAL.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Payment")]
    public partial class Payment
    {
        public int Id { get; set; }

        public long? OrderId { get; set; }

        public decimal? TotalAmount { get; set; }

        public decimal? PaidAmount { get; set; }

        public decimal? BalanceAmount { get; set; }

        public int? CustomerId { get; set; }

        public int? PaymentDetailsId { get; set; }

        public bool? Status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }

        public virtual Order Order { get; set; }

        public virtual PaymentDetail PaymentDetail { get; set; }
    }
}
