namespace _1670webdemo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sang01.Staff")]
    public partial class Staff
    {
        [StringLength(50)]
        public string StaffID { get; set; }

        [Required]
        [StringLength(50)]
        public string StaffName { get; set; }

        [Required]
        [StringLength(50)]
        public string StaffEmail { get; set; }

        public int StaffAge { get; set; }

        [Required]
        [StringLength(50)]
        public string StaffAddr { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        public virtual Account Account { get; set; }
    }
}
