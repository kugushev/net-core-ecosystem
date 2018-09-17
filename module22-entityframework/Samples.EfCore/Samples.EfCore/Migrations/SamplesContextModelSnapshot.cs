﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Samples.EfCore;

namespace Samples.EfCore.Migrations
{
    [DbContext(typeof(SamplesContext))]
    partial class SamplesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Samples.EfCore.Bar", b =>
                {
                    b.Property<int>("BarId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("BarId");

                    b.ToTable("Bar");
                });

            modelBuilder.Entity("Samples.EfCore.LegalEntity", b =>
                {
                    b.Property<string>("EGRUL");

                    b.Property<string>("INN");

                    b.Property<Guid>("SuperId");

                    b.HasKey("EGRUL", "INN");

                    b.ToTable("LegalEntity");
                });

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

                    b.Property<int?>("FavoriteBarId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("FullName");

                    b.Property<int?>("NegativeBarBarId");

                    b.Property<bool?>("Sex");

                    b.Property<bool>("UniversityDegree")
                        .HasColumnName("UniDegree");

                    b.Property<string>("UniversityGovNum");

                    b.HasKey("Id");

                    b.HasIndex("FavoriteBarId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("NegativeBarBarId");

                    b.HasIndex("Sex");

                    b.HasIndex("UniversityGovNum");

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

            modelBuilder.Entity("Samples.EfCore.Unversity", b =>
                {
                    b.Property<string>("GovNum")
                        .ValueGeneratedOnAdd();

                    b.HasKey("GovNum");

                    b.ToTable("Unversity");
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

            modelBuilder.Entity("Samples.EfCore.Student", b =>
                {
                    b.HasOne("Samples.EfCore.Bar", "FavoriteBar")
                        .WithMany("GoodStudents")
                        .HasForeignKey("FavoriteBarId");

                    b.HasOne("Samples.EfCore.Bar", "NegativeBar")
                        .WithMany("BadStudents")
                        .HasForeignKey("NegativeBarBarId");

                    b.HasOne("Samples.EfCore.Unversity", "University")
                        .WithMany()
                        .HasForeignKey("UniversityGovNum");
                });
#pragma warning restore 612, 618
        }
    }
}
