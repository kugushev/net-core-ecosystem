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
    [Migration("20180915154816_AddRequirements")]
    partial class AddRequirements
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Samples.EfCore.LegalEntity", b =>
                {
                    b.Property<string>("Name");

                    b.Property<string>("Registration");

                    b.HasKey("Name", "Registration");

                    b.ToTable("LegalEntity");
                });

            modelBuilder.Entity("Samples.EfCore.Lesson", b =>
                {
                    b.Property<int>("Id");

                    b.Property<DateTime?>("Date");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Lesson");
                });

            modelBuilder.Entity("Samples.EfCore.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<bool>("UniversityDegree");

                    b.Property<string>("UniversityGovNum");

                    b.HasKey("Id");

                    b.HasIndex("UniversityGovNum");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Samples.EfCore.University", b =>
                {
                    b.Property<string>("GovNum")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("GovNum");

                    b.ToTable("University");
                });

            modelBuilder.Entity("Samples.EfCore.Student", b =>
                {
                    b.HasOne("Samples.EfCore.University", "University")
                        .WithMany()
                        .HasForeignKey("UniversityGovNum");
                });
#pragma warning restore 612, 618
        }
    }
}
