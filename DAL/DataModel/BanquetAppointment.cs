namespace DAL.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BanquetAppointment")]
    public partial class BanquetAppointment
    {
        public int Id { get; set; }

        public int? CustomerId { get; set; }

        public DateTime? BookingDate { get; set; }

        public int? BanquetHallId { get; set; }

        [StringLength(50)]
        public string EventTitle { get; set; }

        [StringLength(500)]
        public string EventDesc { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public virtual BanquetHall BanquetHall { get; set; }
    }
}
