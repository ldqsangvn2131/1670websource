namespace _1670webdemo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sang01.Trainee")]
    public partial class Trainee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trainee()
        {
            CourseDetails = new HashSet<CourseDetail>();
        }
        [Key]
        [StringLength(50)]
        [Display(Name = "Trainee ID")]
        public string TraineeID { get; set; }

        [Required]
        [Display(Name = "Trainee Name")]
        [StringLength(50)]
        public string TraineeName { get; set; }

        [Required]
        [Display(Name = "Trainee Email")]
        [StringLength(50)]
        public string TraineeEmail { get; set; }
        [Display(Name = "Trainee Age")]
        public int TraineeAge { get; set; }

        [Required]
        [Display(Name = "Trainee Date of Birth")]
        [StringLength(50)]
        public string TraineeDoB { get; set; }

        [Required]
        [Display(Name = "Trainee Edu")]
        [StringLength(50)]
        public string TraineeEdu { get; set; }

        [Required]
        [Display(Name = "Username")]
        [StringLength(50)]
        public string Username { get; set; }

        public virtual Account Account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseDetail> CourseDetails { get; set; }
    }
}
