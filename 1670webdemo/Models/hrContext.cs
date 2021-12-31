using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace _1670webdemo.Models
{
    public partial class hrContext : DbContext
    {
        public hrContext()
            : base("name=hrContext")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CourseDetail> CourseDetails { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<Trainee> Trainees { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.AccountType)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Staffs)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Trainees)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Trainers)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.CatID)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.CatName)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.CatDesc)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Courses)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CourseDetail>()
                .Property(e => e.CourseDetailID)
                .IsUnicode(false);

            modelBuilder.Entity<CourseDetail>()
                .Property(e => e.TrainerID)
                .IsUnicode(false);

            modelBuilder.Entity<CourseDetail>()
                .Property(e => e.TraineeID)
                .IsUnicode(false);

            modelBuilder.Entity<CourseDetail>()
                .Property(e => e.TopicID)
                .IsUnicode(false);

            modelBuilder.Entity<CourseDetail>()
                .Property(e => e.CourseID)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.CourseID)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.CourseName)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.CourseDesc)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.CatID)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.TrainerID)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.CourseDetails)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Topics)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.StaffID)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.StaffName)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.StaffEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.StaffAddr)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Topic>()
                .Property(e => e.TopicID)
                .IsUnicode(false);

            modelBuilder.Entity<Topic>()
                .Property(e => e.TopicName)
                .IsUnicode(false);

            modelBuilder.Entity<Topic>()
                .Property(e => e.TopicDesc)
                .IsUnicode(false);

            modelBuilder.Entity<Topic>()
                .Property(e => e.CourseID)
                .IsUnicode(false);

            modelBuilder.Entity<Topic>()
                .HasMany(e => e.CourseDetails)
                .WithRequired(e => e.Topic)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trainee>()
                .Property(e => e.TraineeID)
                .IsUnicode(false);

            modelBuilder.Entity<Trainee>()
                .Property(e => e.TraineeName)
                .IsUnicode(false);

            modelBuilder.Entity<Trainee>()
                .Property(e => e.TraineeEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Trainee>()
                .Property(e => e.TraineeDoB)
                .IsUnicode(false);

            modelBuilder.Entity<Trainee>()
                .Property(e => e.TraineeEdu)
                .IsUnicode(false);

            modelBuilder.Entity<Trainee>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Trainee>()
                .HasMany(e => e.CourseDetails)
                .WithRequired(e => e.Trainee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trainer>()
                .Property(e => e.TrainerID)
                .IsUnicode(false);

            modelBuilder.Entity<Trainer>()
                .Property(e => e.TrainerName)
                .IsUnicode(false);

            modelBuilder.Entity<Trainer>()
                .Property(e => e.TrainerEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Trainer>()
                .Property(e => e.TrainerSpec)
                .IsUnicode(false);

            modelBuilder.Entity<Trainer>()
                .Property(e => e.TrainerAddr)
                .IsUnicode(false);

            modelBuilder.Entity<Trainer>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Trainer>()
                .HasMany(e => e.CourseDetails)
                .WithRequired(e => e.Trainer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trainer>()
                .HasMany(e => e.Courses)
                .WithRequired(e => e.Trainer)
                .WillCascadeOnDelete(true);
        }
    }
}
