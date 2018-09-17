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

        #region Spoiler
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(new LoggerFactory());
            optionsBuilder.UseNpgsql(@"UserID=postgres;Password=debug;Host=localhost;Port=5432;Database=sample");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().Ignore(x => x.Counter);
            modelBuilder.Entity<Bar>();
            modelBuilder.Entity<LegalEntity>().HasKey(x => new { x.EGRUL, x.INN });
            modelBuilder.Entity<Student>().Property(x => x.Name).HasColumnName("FullName");
            modelBuilder.Entity<Student>().HasOne<Bar>(x => x.NegativeBar);
            modelBuilder.Entity<Bar>().HasMany<Student>(x => x.BadStudents).WithOne("NegativeBar");
            modelBuilder.Entity<Student>().HasIndex(x => x.Sex);
            modelBuilder.Entity<Student>().HasIndex(x => x.Name).IsUnique();
            #region Spoilers
            modelBuilder.Entity<LessonTeacher>().HasKey(x => new { x.LessonId, x.TeacherId });
            modelBuilder.Entity<LessonTeacher>()
                .HasOne(x => x.Lesson)
                .WithMany(x => x.LessonTeachers)
                .HasForeignKey(x => x.LessonId);
            modelBuilder.Entity<LessonTeacher>()
                .HasOne(x => x.Teacher)
                .WithMany(x => x.LessonTeachers)
                .HasForeignKey(x => x.TeacherId);
            #endregion
        }

    }
    
    class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Column("UniDegree")]
        public bool UniversityDegree { get; set; }

        public bool? Sex { get; set; }

        public int Counter { get; set; }

        public Unversity University { get; set; }

        [ForeignKey("FavoriteBarId")]
        public Bar FavoriteBar { get; set; }

        public Bar NegativeBar { get; set; }

    }

    class Unversity
    {
        [Key]
        public string GovNum { get; set; }
    }

    class LegalEntity
    {
        public string EGRUL { get; set; }
        public string INN { get; set; }

        public Guid SuperId { get; set; }
    }


    class Bar
    {
        public int BarId { get; set; }
        public string Name { get; set; }
        [InverseProperty(nameof(Student.FavoriteBar))]
        public List<Student> GoodStudents { get; set; }
        public List<Student> BadStudents { get; set; }
    }


    #region Spoiler
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
    #endregion
}
