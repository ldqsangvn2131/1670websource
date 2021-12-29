namespace _1670webdemo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sang01.Trainer")]
    public partial class Trainer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trainer()
        {
            CourseDetails = new HashSet<CourseDetail>();
            Courses = new HashSet<Course>();
        }
        [Key]
        [StringLength(50)]
        [Display(Name = "Trainer ID")]
        public string TrainerID { get; set; }

        [Required]
        [Display(Name = "Trainer Name")]
        [StringLength(50)]
        public string TrainerName { get; set; }

        [Required]
        [Display(Name = "Trainer Email")]
        [StringLength(50)]
        public string TrainerEmail { get; set; }

        [Required]
        [Display(Name = "Trainer Spec")]
        [StringLength(50)]
        public string TrainerSpec { get; set; }
        [Display(Name = "Trainer Age")]
        public int TrainerAge { get; set; }

        [Required]
        [Display(Name = "Trainer Address")]
        [StringLength(50)]
        public string TrainerAddr { get; set; }

        [Required]
        [Display(Name = "Username")]
        [StringLength(50)]
        public string Username { get; set; }

        public virtual Account Account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseDetail> CourseDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course> Courses { get; set; }
    }
}
