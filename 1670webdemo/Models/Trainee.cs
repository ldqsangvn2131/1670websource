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

        [StringLength(50)]
        public string TraineeID { get; set; }

        [Required]
        [StringLength(50)]
        public string TraineeName { get; set; }

        [Required]
        [StringLength(50)]
        public string TraineeEmail { get; set; }

        public int TraineeAge { get; set; }

        [Required]
        [StringLength(50)]
        public string TraineeDoB { get; set; }

        [Required]
        [StringLength(50)]
        public string TraineeEdu { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        public virtual Account Account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseDetail> CourseDetails { get; set; }
    }
}
