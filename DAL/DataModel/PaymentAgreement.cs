namespace DAL.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PaymentAgreement")]
    public partial class PaymentAgreement
    {
        public int Id { get; set; }

        public int CustomerPaymentPlanId { get; set; }

        public int ImageId { get; set; }

        public bool IsEmailSent { get; set; }

        public bool IsSmsSent { get; set; }

        [Column(TypeName = "date")]
        public DateTime SignedDate { get; set; }

        public int CreatedBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreatedDate { get; set; }

        public virtual CustomerPaymentPlan CustomerPaymentPlan { get; set; }
    }
}
