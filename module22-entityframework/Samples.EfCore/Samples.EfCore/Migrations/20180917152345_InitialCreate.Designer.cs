﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Samples.EfCore;

namespace Samples.EfCore.Migrations
{
    [DbContext(typeof(SamplesContext))]
    [Migration("20180917152345_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Samples.EfCore.Lesson", b =>
                {
                    b.Property<int>("Id");

                    b.Property<DateTime?>("Date");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Lesson");
                });

            modelBuilder.Entity("Samples.EfCore.LessonTeacher", b =>
                {
                    b.Property<int>("LessonId");

                    b.Property<int>("TeacherId");

                    b.HasKey("LessonId", "TeacherId");

                    b.HasIndex("TeacherId");

                    b.ToTable("LessonTeacher");
                });

            modelBuilder.Entity("Samples.EfCore.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<bool>("UniversityDegree");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Samples.EfCore.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("Samples.EfCore.LessonTeacher", b =>
                {
                    b.HasOne("Samples.EfCore.Lesson", "Lesson")
                        .WithMany("LessonTeachers")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Samples.EfCore.Teacher", "Teacher")
                        .WithMany("LessonTeachers")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
