namespace DAL.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ScheduleFollowup")]
    public partial class ScheduleFollowup
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string OutComes { get; set; }
    }
}
