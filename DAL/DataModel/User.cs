namespace DAL.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            AssignCustomers = new HashSet<AssignCustomer>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Salt { get; set; }

        [StringLength(100)]
        public string Hash { get; set; }

        public DateTime? CreatedOn { get; set; }

        public bool? Status { get; set; }

        public int? RoleId { get; set; }

        public int? UserTypeId { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssignCustomer> AssignCustomers { get; set; }
        public virtual Role Role { get; set; }
    }
}
