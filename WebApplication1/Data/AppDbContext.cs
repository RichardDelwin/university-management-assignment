﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Course> Courses{ get; set; }

        public DbSet<College> Colleges { get; set; }
        public DbSet<University> Universities{ get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<CollegeCourse> CollegeCourses { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            //composite keys
            modelBuilder.Entity<CollegeCourse>().HasKey(c => new { c.CollegeId, c.CourseId });

            modelBuilder.Entity<College>().HasOne(c => c.University).WithMany(c => c.Colleges).HasForeignKey(c => c.UniversityId);
            //modelBuilder.Entity<CollegeCourse>().HasMany(cc => cc.College).WithMany(c => c.).HasForeignKey(cc => cc.CollegeId);
        }


    }
}
