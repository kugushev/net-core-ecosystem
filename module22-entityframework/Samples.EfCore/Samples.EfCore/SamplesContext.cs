﻿using Microsoft.EntityFrameworkCore;
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
            optionsBuilder.UseNpgsql(@"UserID=postgres;Password=p@ssw0rd;Host=localhost;Port=5432;Database=sample");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
        public string Name { get; set; }
        public bool UniversityDegree { get; set; }
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
