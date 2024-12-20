﻿// <auto-generated />
using System;
using IntroductionToEF.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IntroductionToEF.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20241018131500_update5th")]
    partial class update5th
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IntroductionToEF.Model.Assignment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("IntroductionToEF.Model.AssignmentResult", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("AssignmentID")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AssignmentID");

                    b.HasIndex("StudentID");

                    b.ToTable("AssignmentResults");
                });

            modelBuilder.Entity("IntroductionToEF.Model.Course", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("CourseID")
                        .HasColumnType("int");

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("IntroductionToEF.Model.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnrollmentID"));

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("EnrollmentID");

                    b.HasIndex("CourseID");

                    b.HasIndex("StudentID");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("IntroductionToEF.Model.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("IntroductionToEF.Model.StudentCard", b =>
                {
                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<string>("ClassIRN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Period")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentID");

                    b.ToTable("StudentCards");
                });

            modelBuilder.Entity("IntroductionToEF.Model.Assignment", b =>
                {
                    b.HasOne("IntroductionToEF.Model.Course", "Course")
                        .WithMany("Assignments")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("IntroductionToEF.Model.AssignmentResult", b =>
                {
                    b.HasOne("IntroductionToEF.Model.Assignment", "Assignment")
                        .WithMany()
                        .HasForeignKey("AssignmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IntroductionToEF.Model.Student", "Student")
                        .WithMany("AssignmentResults")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignment");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("IntroductionToEF.Model.Course", b =>
                {
                    b.HasOne("IntroductionToEF.Model.Course", null)
                        .WithMany("Courses")
                        .HasForeignKey("CourseID");
                });

            modelBuilder.Entity("IntroductionToEF.Model.Enrollment", b =>
                {
                    b.HasOne("IntroductionToEF.Model.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IntroductionToEF.Model.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("IntroductionToEF.Model.StudentCard", b =>
                {
                    b.HasOne("IntroductionToEF.Model.Student", "Student")
                        .WithOne("StudentCard")
                        .HasForeignKey("IntroductionToEF.Model.StudentCard", "StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("IntroductionToEF.Model.Course", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("Courses");

                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("IntroductionToEF.Model.Student", b =>
                {
                    b.Navigation("AssignmentResults");

                    b.Navigation("Enrollments");

                    b.Navigation("StudentCard")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
