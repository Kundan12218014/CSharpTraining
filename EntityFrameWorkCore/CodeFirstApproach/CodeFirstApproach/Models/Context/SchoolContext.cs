using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstApproach.Models.Context
{
    public class SchoolContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=SchoolDB;Integrated Security=True;Trust Server Certificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student() { Id = 1, Name = "Kundan", Email = "Kundan@gmail.com", PhoneNumber = 123456534, BranchId = 1 },
                new Student() { Id = 2, Name = "Nikhil", Email = "Nikhil@gmail.com", PhoneNumber = 345342342, BranchId = 2 },
                new Student() { Id = 3, Name = "Gaurav", Email = "Gaurav@gmail.com", PhoneNumber = 892873433, BranchId = 3 }
                );
            modelBuilder.Entity<Branch>().HasData(
                new Branch() { Id=1,Name="Maheru"},
                new Branch() { Id=2,Name="Jalandhar"},
                new Branch() { Id=3,Name="Phaghwara"}
                );
            modelBuilder.Entity<Course>().HasData(
                new Course() { CourseId = 1, CourseName = "Mathematics" },
                new Course() { CourseId = 2, CourseName = "Science" },
                new Course() { CourseName="Hindi",CourseId=3}
                );


            modelBuilder.Entity<Address>().HasData(
                new Address() { Id=1,City="Vaishali",Country="India",State="Bihar",StudentId=1},
                new Address() { Id=2,City="Lalaganj",Country="India",State="UtterPradesh", StudentId = 2 },
                new Address() { Id=3,City="Patna",Country="India",State="Bihar", StudentId = 3}
                //new Address() { Id=4,City="Vaishali",Country="India",State="Bihar", StudentId = 1}
             
                );
        }


    }
}
