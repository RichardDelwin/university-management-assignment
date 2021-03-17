﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudentStudentCourseCollege", b =>
                {
                    b.Property<int>("StudentCourseAndCollegesId")
                        .HasColumnType("int");

                    b.Property<int>("StudentsId")
                        .HasColumnType("int");

                    b.HasKey("StudentCourseAndCollegesId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("StudentStudentCourseCollege");
                });

            modelBuilder.Entity("WebApplication1.Models.College", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UniversityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UniversityId");

                    b.ToTable("Colleges");
                });

            modelBuilder.Entity("WebApplication1.Models.CollegeCourse", b =>
                {
                    b.Property<int>("CollegeId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("CollegeId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("CollegeCourses");
                });

            modelBuilder.Entity("WebApplication1.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("courseName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("WebApplication1.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("WebApplication1.Models.StudentCourseCollege", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CollegeId")
                        .HasColumnType("int");

                    b.Property<int?>("CollegesCollegeId")
                        .HasColumnType("int");

                    b.Property<int?>("CollegesCourseId")
                        .HasColumnType("int");

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("CollegesCollegeId", "CollegesCourseId");

                    b.ToTable("StudentCourseColleges");
                });

            modelBuilder.Entity("WebApplication1.Models.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("StudentStudentCourseCollege", b =>
                {
                    b.HasOne("WebApplication1.Models.StudentCourseCollege", null)
                        .WithMany()
                        .HasForeignKey("StudentCourseAndCollegesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Models.College", b =>
                {
                    b.HasOne("WebApplication1.Models.University", "University")
                        .WithMany("Colleges")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("WebApplication1.Models.CollegeCourse", b =>
                {
                    b.HasOne("WebApplication1.Models.College", "College")
                        .WithMany("CollegeCourses")
                        .HasForeignKey("CollegeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Course", "Course")
                        .WithMany("OfferingColleges")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("College");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("WebApplication1.Models.StudentCourseCollege", b =>
                {
                    b.HasOne("WebApplication1.Models.Course", "Courses")
                        .WithMany("Students")
                        .HasForeignKey("CourseId");

                    b.HasOne("WebApplication1.Models.CollegeCourse", "Colleges")
                        .WithMany()
                        .HasForeignKey("CollegesCollegeId", "CollegesCourseId");

                    b.Navigation("Colleges");

                    b.Navigation("Courses");
                });

            modelBuilder.Entity("WebApplication1.Models.College", b =>
                {
                    b.Navigation("CollegeCourses");
                });

            modelBuilder.Entity("WebApplication1.Models.Course", b =>
                {
                    b.Navigation("OfferingColleges");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("WebApplication1.Models.University", b =>
                {
                    b.Navigation("Colleges");
                });
#pragma warning restore 612, 618
        }
    }
}
