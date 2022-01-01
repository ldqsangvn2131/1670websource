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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseDetailID { get; set; }

        [Required]
        [StringLength(50)]
        public string TrainerID { get; set; }

        [Required]
        [StringLength(50)]
        public string TraineeID { get; set; }

        [Required]
        [StringLength(50)]
        public string TopicID { get; set; }

        [Required]
        [StringLength(50)]
        public string CourseID { get; set; }

        public virtual Course Course { get; set; }

        public virtual Topic Topic { get; set; }

        public virtual Trainer Trainer { get; set; }

        public virtual Trainee Trainee { get; set; }
    }
}
