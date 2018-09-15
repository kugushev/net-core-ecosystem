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
    [Migration("20180915162658_Navigation2")]
    partial class Navigation2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Samples.EfCore.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Number");

                    b.HasKey("Id");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("Samples.EfCore.LegalEntity", b =>
                {
                    b.Property<string>("Name");

                    b.Property<string>("Registration");

                    b.Property<DateTime>("LastUpdated");

                    b.HasKey("Name", "Registration");

                    b.ToTable("LegalEntity");
                });

            modelBuilder.Entity("Samples.EfCore.Lesson", b =>
                {
                    b.Property<int>("Id");

                    b.Property<DateTime?>("Date")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Lesson");
                });

            modelBuilder.Entity("Samples.EfCore.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Group_Id");

                    b.Property<int>("InterviewGroupId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(512);

                    b.Property<bool>("UniversityDegree");

                    b.Property<string>("UniversityGovNum");

                    b.HasKey("Id");

                    b.HasIndex("Group_Id");

                    b.HasIndex("InterviewGroupId");

                    b.HasIndex("UniversityGovNum");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Samples.EfCore.University", b =>
                {
                    b.Property<string>("GovNum")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.HasKey("GovNum");

                    b.ToTable("University");
                });

            modelBuilder.Entity("Samples.EfCore.Student", b =>
                {
                    b.HasOne("Samples.EfCore.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("Group_Id");

                    b.HasOne("Samples.EfCore.Group", "InterviewGroup")
                        .WithMany("Interviewers")
                        .HasForeignKey("InterviewGroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Samples.EfCore.University", "University")
                        .WithMany()
                        .HasForeignKey("UniversityGovNum");
                });
#pragma warning restore 612, 618
        }
    }
}
