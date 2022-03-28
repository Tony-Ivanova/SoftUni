﻿namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class StudentSystemContext:DbContext
    {
        //public StudentSystemContext()
        //{

        //}

        public StudentSystemContext(DbContextOptions contextOptions)
        :base(contextOptions)
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConfigurationString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Student>()
                .Property(p => p.Name)
                .IsUnicode();

            modelBuilder.Entity<Student>()
                .Property(p => p.PhoneNumber)
                .IsRequired(false)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(p => p.Birthday)
                .IsRequired(false);


            modelBuilder
                .Entity<Course>()
                .Property(p => p.Description)
                .IsRequired(false)
                .IsUnicode();

            modelBuilder
                .Entity<Resource>()
                .Property(p => p.Name)
                .IsUnicode();

            modelBuilder
                .Entity<Resource>()
                .Property(p => p.Url)
                .IsUnicode(false);

            modelBuilder
                .Entity<Resource>()
                .HasOne(p => p.Course)
                .WithMany(p => p.Resources)
                .HasForeignKey(fk => fk.CourseId);
                



            modelBuilder.Entity<Homework>()
                .Property(h => h.Content)
                .IsUnicode(false);
            
     
            
            modelBuilder
                .Entity<StudentCourse>()
                .HasKey(ck => new {ck.StudentId, ck.CourseId});



            modelBuilder
                .Entity<StudentCourse>()
                .HasOne(p => p.Student)
                .WithMany(p => p.CourseEnrollments)
                .HasForeignKey(fk => fk.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<StudentCourse>()
                .HasOne(e => e.Course)
                .WithMany(p => p.StudentsEnrolled)
                .HasForeignKey(fk => fk.CourseId);

            modelBuilder
                .Entity<Homework>()
                .HasOne(p => p.Student)
                .WithMany(p => p.HomeworkSubmissions)
                .HasForeignKey(fk => fk.StudentId);


            modelBuilder
                .Entity<Homework>()
                .HasOne(p => p.Course)
                .WithMany(p => p.HomeworkSubmissions)
                .HasForeignKey(fk => fk.CourseId);
                
        }
    }
}