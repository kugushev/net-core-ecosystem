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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"UserID=postgres;Password=p@ssw0rd;Host=localhost;Port=5432;Database=sample");
        }

        
    }

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool UniversityDegree { get; set; }
    }
}
