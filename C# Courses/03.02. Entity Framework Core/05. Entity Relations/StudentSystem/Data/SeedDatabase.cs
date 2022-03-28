//namespace P01_StudentSystem.Data
//{
//    using Microsoft.EntityFrameworkCore;
//    using Models;
//  //  using Models.Enums;
//    using System;

//    internal static class SeedDatabase
//    {
//        public static void Seed(ModelBuilder modelBuilder)
//        {
//            modelBuilder
//                .Entity<Student>()
//                .HasData(

//                 new Student
//                 {
//                     StudentId = 1,
//                     Name = "Gosho Goshov",
//                     PhoneNumber = "1234567899",
//                     RegisteredOn = DateTime.Now
//                 },

//                 new Student
//                 {
//                     StudentId = 2,
//                     Name = "Pesho Peshov",
//                     RegisteredOn = DateTime.Now
//                 });


//            modelBuilder.Entity<Course>()
//                .HasData(
//                new Course
//                {
//                    CourseId = 1,
//                    Name = "C# OOP",
//                    StartDate = DateTime.Now
//                },

//                new Course
//                {
//                    CourseId = 2,
//                    Name = "C# DB",
//                    StartDate = DateTime.Now
//                });

//            modelBuilder.Entity<Resource>()
//                .HasData(

//                new Resource
//                {
//                    ResourceId = 1,
//                    CourseId = 1,
//                    Name = "C# OOP Advanced Dictionaries",
//                    ResourceType = ResourceType.Document
//                },

//                new Resource
//                {
//                    ResourceId = 2,
//                    CourseId = 2,
//                    Name = "C# EntityFramework Book",
//                    ResourceType = ResourceType.Video
//                });

//            modelBuilder.Entity<Homework>()
//                .HasData(

//                new Homework
//                {
//                    HomeworkId = 1,
//                    ContentType = ContentType.Pdf,
//                    StudentId = 1,
//                    CourseId = 2,
//                    SubmissionTime = DateTime.Now
//                },

//                new Homework
//                {
//                    HomeworkId = 2,
//                    ContentType = ContentType.Zip,
//                    StudentId = 2,
//                    CourseId = 1,
//                    SubmissionTime = DateTime.Now
//                }); 
//        }

        
//    }
//}
