using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Samples.EfCore
{
    class SamplesContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<University> Groups { get; set; }
        public DbSet<Lesson> Lessons { get; set; }        
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(new LoggerFactory());
            optionsBuilder.UseNpgsql(@"UserID=postgres;Password=p@ssw0rd;Host=localhost;Port=5432;Database=sample");                        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lesson>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Lesson>().Property(x => x.Date).IsRequired(true);
            modelBuilder.Entity<University>().Ignore(x => x.Counter);
            modelBuilder.Entity<University>().Property(x => x.Name).HasMaxLength(256);
            modelBuilder.Entity<LegalEntity>().HasKey(x => new { x.Name, x.Registration });
            modelBuilder.Entity<LegalEntity>().Property<DateTime>("LastUpdated");
            modelBuilder.Entity<University>().HasMany<Group>();

            modelBuilder.Entity<LessonTeacher>().HasKey(x => new { x.LessonId, x.TeacherId });
            modelBuilder.Entity<LessonTeacher>()
                .HasOne(x => x.Lesson)
                .WithMany(x => x.LessonTeachers)
                .HasForeignKey(x => x.LessonId);
            modelBuilder.Entity<LessonTeacher>()
                .HasOne(x => x.Teacher)
                .WithMany(x => x.LessonTeachers)
                .HasForeignKey(x => x.TeacherId);

            modelBuilder.Entity<Student>().HasIndex(x => x.Name);
            modelBuilder.Entity<Student>().HasIndex(x => x.GovNum).IsUnique();
        }

    }

    class Student
    {
        public int Id { get; set; }

        [MaxLength(512)]
        [Required]
        public string Name { get; set; }
        public bool UniversityDegree { get; set; }
        public University University { get; set; }
        public string GovNum { get; set; }

        [NotMapped]
        public int? Counter { get; set; }

        [ForeignKey("Group_Id")]
        public Group Group { get; set; }

        public int? InterviewGroupId { get; set; }
        public Group InterviewGroup { get; set; }
    }

    class University
    {
        [Key]
        public string GovNum { get; set; }
        public string Name { get; set; }
        public int Counter { get; set; }
    }

    class LegalEntity
    {
        public string Name { get; set; }
        public string Registration { get; set; }
    }

    class Group
    {
        public int Id { get; set; }
        public string Number { get; set; }
        [InverseProperty("Group")]
        public List<Student> Students { get; set; }
        [InverseProperty("InterviewGroup")]
        public List<Student> Interviewers { get; set; }
    }

    [Table("Lesson")]
    class Lesson
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public List<LessonTeacher> LessonTeachers { get; set; }
    }

    [Table("Teacher")]
    class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<LessonTeacher> LessonTeachers { get; set; }
    }

    class LessonTeacher
    {
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
