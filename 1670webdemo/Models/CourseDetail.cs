namespace _1670webdemo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sang01.CourseDetail")]
    public partial class CourseDetail
    {
        [Key]
        [Display(Name = "Course ID")]
        [Column(Order = 0)]
        [StringLength(50)]
        public string CourseID { get; set; }

        [Key]
        [Display(Name = "Trainer ID")]
        [Column(Order = 1)]
        [StringLength(50)]
        public string TrainerID { get; set; }

        [Key]
        [Display(Name = "Trainee ID")]
        [Column(Order = 2)]
        [StringLength(50)]
        public string TraineeID { get; set; }

        [Key]
        [Column(Order = 3)]
        [Display(Name = "Topic ID")]
        [StringLength(50)]
        public string TopicID { get; set; }

        public virtual Course Course { get; set; }

        public virtual Topic Topic { get; set; }

        public virtual Trainee Trainee { get; set; }

        public virtual Trainer Trainer { get; set; }
    }
}
