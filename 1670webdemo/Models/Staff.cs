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
        [Key]
        [StringLength(50)]
        [RegularExpression("^S+[0-9]", ErrorMessage = "Staff ID must be S + number")]
        [Display(Name = "Staff ID")]
        public string StaffID { get; set; }

        [Required]
        [Display(Name = "Staff Name")]
        [StringLength(50)]
        public string StaffName { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Display(Name = "Staff Email")]
        [StringLength(50)]
        public string StaffEmail { get; set; }

        [Required]
        [Display(Name = "Staff Age")]
        public int StaffAge { get; set; }

        [Required]
        [Display(Name = "Staff Address")]
        [StringLength(50)]
        public string StaffAddr { get; set; }

        [Required]
        [Display(Name = "Username")]
        [StringLength(50)]
        public string Username { get; set; }

        public virtual Account Account { get; set; }
    }
}
