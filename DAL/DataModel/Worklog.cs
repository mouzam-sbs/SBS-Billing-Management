namespace DAL.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Worklog")]
    public partial class Worklog
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Purpose { get; set; }

        [StringLength(50)]
        public string FoolowUpNotes { get; set; }

        public DateTime? NextFollowDate { get; set; }

        public int? CustomerId { get; set; }

        public int? FollowTypeId { get; set; }

        public int? ScheduleFollowId { get; set; }
    }
}
