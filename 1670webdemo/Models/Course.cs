namespace _1670webdemo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sang01.Courses")]
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            CourseDetails = new HashSet<CourseDetail>();
            Topics = new HashSet<Topic>();
        }

        [Key]
        [Display(Name = "Course ID")]
        [StringLength(50)]
        public string CourseID { get; set; }

        [Required]
        [Display(Name = "Course Name")]
        [StringLength(50)]
        public string CourseName { get; set; }

        [Required]
        [Display(Name = "Course Description")]
        [StringLength(50)]
        public string CourseDesc { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Category ID")]
        public string CatID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Trainer ID")]
        public string TrainerID { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseDetail> CourseDetails { get; set; }

        public virtual Trainer Trainer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Topic> Topics { get; set; }
    }
}
