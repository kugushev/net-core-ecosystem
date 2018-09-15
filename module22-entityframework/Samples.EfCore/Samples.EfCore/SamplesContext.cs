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
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\sql2014;Initial Catalog=Samples_EfCore;Integrated Security=SSPI;MultipleActiveResultSets=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(x => x.HasUniversityDegree).HasColumnName("UniversityDegree");
            modelBuilder.Entity<Student>().Ignore(x => x.Validator);
            modelBuilder.Entity<Student>().Property(x => x.FullName).IsRequired();

            modelBuilder.Entity<Log>().Property(x => x.Time).HasDefaultValueSql("CONVERT(date, GETDATE())");
        }
    }

    class Student
    {
        public int Id { get; set; }

        [Required]
        [Column("Name")]
        [MaxLength(1024)]
        public string FullName { get; set; }

        [Required]
        public bool HasUniversityDegree { get; set; }

        [NotMapped]
        public int Counter { get; set; }
        public int Validator { get; set; }

        public List<Interview> Interviews { get; set; }
    }

    class Interview
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int Score { get; set; }
        public string Feedback { get; set; }

    }

    class Log
    {
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Identity { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Time { get; set; }

        public string Description { get; set; }
    }
}
