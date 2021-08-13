﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Red_Social.Model.Models.Context;

namespace Red_Social.Model.Migrations
{
    [DbContext(typeof(EscuelitaContext))]
    [Migration("20210812073902_addingNewPropertyNumberOfStudentsInTableCourses2")]
    partial class addingNewPropertyNumberOfStudentsInTableCourses2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Red_Social.Model.Models.Courses.Courses", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Day")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FinalTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InitialTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfStudents")
                        .HasColumnType("int");

                    b.Property<int>("quota")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Red_Social.Model.Models.MatterAssignment.MatterAssignment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TeachersId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CoursesId");

                    b.HasIndex("TeachersId");

                    b.ToTable("matterAssignments");
                });

            modelBuilder.Entity("Red_Social.Model.Models.MatterSelection.MatterSelection", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int?>("StudentsID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CoursesId");

                    b.HasIndex("StudentsID");

                    b.ToTable("matterSelections");
                });

            modelBuilder.Entity("Red_Social.Model.Models.Students.Students", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Enrollment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Red_Social.Model.Models.Teachers.Teachers", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Red_Social.Model.Models.MatterAssignment.MatterAssignment", b =>
                {
                    b.HasOne("Red_Social.Model.Models.Courses.Courses", "Courses")
                        .WithMany("MatterAssignments")
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Red_Social.Model.Models.Teachers.Teachers", "Teachers")
                        .WithMany("matterSelections")
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Courses");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("Red_Social.Model.Models.MatterSelection.MatterSelection", b =>
                {
                    b.HasOne("Red_Social.Model.Models.Courses.Courses", "Courses")
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Red_Social.Model.Models.Students.Students", "Students")
                        .WithMany("MatterSelections")
                        .HasForeignKey("StudentsID");

                    b.Navigation("Courses");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("Red_Social.Model.Models.Courses.Courses", b =>
                {
                    b.Navigation("MatterAssignments");
                });

            modelBuilder.Entity("Red_Social.Model.Models.Students.Students", b =>
                {
                    b.Navigation("MatterSelections");
                });

            modelBuilder.Entity("Red_Social.Model.Models.Teachers.Teachers", b =>
                {
                    b.Navigation("matterSelections");
                });
#pragma warning restore 612, 618
        }
    }
}
