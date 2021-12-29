namespace _1670webdemo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sang01.Category")]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Courses = new HashSet<Course>();
        }

        [Key]
        [Display(Name = "Category ID")]
        [StringLength(50)]
        public string CatID { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        [StringLength(50)]
        public string CatName { get; set; }

        [StringLength(50)]
        [Display(Name = "Category Description")]
        public string CatDesc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course> Courses { get; set; }
    }
}
