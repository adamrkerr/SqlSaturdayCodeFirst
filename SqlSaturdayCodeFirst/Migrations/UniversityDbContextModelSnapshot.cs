﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SqlSaturdayCodeFirst.Context;
using System;

namespace SqlSaturdayCodeFirst.Migrations
{
    [DbContext(typeof(UniversityDbContext))]
    partial class UniversityDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SqlSaturdayCodeFirst.Context.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<TimeSpan?>("ClassDuration");

                    b.Property<int?>("CourseNumber")
                        .IsRequired();

                    b.Property<int?>("DepartmentId")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<DateTimeOffset?>("EndDate");

                    b.Property<Guid?>("InstructorId");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastChangedByUser")
                        .IsRequired();

                    b.Property<DateTimeOffset?>("LastChangedTimestamp")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTimeOffset?>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("InstructorId");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("SqlSaturdayCodeFirst.Context.CourseEnrollment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CourseId");

                    b.Property<float>("FinalGrade")
                        .HasColumnType("decimal(6,3)");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastChangedByUser")
                        .IsRequired();

                    b.Property<DateTimeOffset?>("LastChangedTimestamp")
                        .IsRequired();

                    b.Property<Guid>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("StudentId");

                    b.ToTable("CourseEnrollments");
                });

            modelBuilder.Entity("SqlSaturdayCodeFirst.Context.Department", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastChangedByUser")
                        .IsRequired();

                    b.Property<DateTimeOffset?>("LastChangedTimestamp")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("SqlSaturdayCodeFirst.Context.Instructor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("BirthDate")
                        .IsRequired();

                    b.Property<int?>("DepartmentId")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<DateTime?>("HireDate")
                        .IsRequired();

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastChangedByUser")
                        .IsRequired();

                    b.Property<DateTimeOffset?>("LastChangedTimestamp")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("MiddleName");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("SqlSaturdayCodeFirst.Context.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("BirthDate")
                        .IsRequired();

                    b.Property<int>("ExpectedGraduationYear");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastChangedByUser")
                        .IsRequired();

                    b.Property<DateTimeOffset?>("LastChangedTimestamp")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("MiddleName");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SqlSaturdayCodeFirst.Context.Course", b =>
                {
                    b.HasOne("SqlSaturdayCodeFirst.Context.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SqlSaturdayCodeFirst.Context.Instructor", "Instructor")
                        .WithMany("Courses")
                        .HasForeignKey("InstructorId");
                });

            modelBuilder.Entity("SqlSaturdayCodeFirst.Context.CourseEnrollment", b =>
                {
                    b.HasOne("SqlSaturdayCodeFirst.Context.Course", "Course")
                        .WithMany("EnrolledStudents")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SqlSaturdayCodeFirst.Context.Student", "Student")
                        .WithMany("EnrolledCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SqlSaturdayCodeFirst.Context.Instructor", b =>
                {
                    b.HasOne("SqlSaturdayCodeFirst.Context.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
