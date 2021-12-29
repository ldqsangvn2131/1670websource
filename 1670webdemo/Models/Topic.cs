namespace _1670webdemo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sang01.Topic")]
    public partial class Topic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Topic()
        {
            CourseDetails = new HashSet<CourseDetail>();
        }
        [Key]
        [Display(Name = "Topic ID")]
        [StringLength(50)]
        public string TopicID { get; set; }

        [Required]
        [Display(Name = "Topic Name")]
        [StringLength(50)]
        public string TopicName { get; set; }

        [Required]
        [Display(Name = "Topic Description")]
        [StringLength(50)]
        public string TopicDesc { get; set; }

        [Required]
        [Display(Name = "Course ID")]
        [StringLength(50)]
        public string CourseID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseDetail> CourseDetails { get; set; }

        public virtual Course Course { get; set; }
    }
}
