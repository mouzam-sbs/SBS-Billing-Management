namespace DAL.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AssignCustomer")]
    public partial class AssignCustomer
    {
       
        public int Id { get; set; }

        public int? CustomerId { get; set; }

        public int? UserId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual User User { get; set; }
    }
}
