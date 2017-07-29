namespace DAL.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserType")]
    public partial class UserType
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? MainUserType { get; set; }

        public bool? Status { get; set; }
    }
}
