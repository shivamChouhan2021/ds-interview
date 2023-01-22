using DotNetCoreWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DotNetCoreWebApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        { 
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Job> Jobs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            base.OnModelCreating(modelBuilder);

            // User Seed Data
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Name = "Shivam Chouhan",
                Email = "shivamchouhan544@gmail.com",
                Password = "123456",
                
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 2,
                Name = "Navin Kumar",
                Email = "navinkumar@gmail.com",
                Password = "1234567"
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 3,
                Name = "Kiran Kher",
                Email = "kiran@gmail.com",
                Password = "12345678"
            });

            // Seeding Job Data
            modelBuilder.Entity<Job>().HasData(new Job
            {
                Id = 1,
                JobCode = "JOB111",
                Title = "DOT NET",
                MinimumQualification = "BCA",
                SortDescription = "Software Engineer",
                LastApplyDate = DateTime.Now,
                UserId = 1
            }) ;

            modelBuilder.Entity<Job>().HasData(new Job
            {
                Id = 2,
                JobCode = "JOB112",
                Title = "PHP",
                MinimumQualification = "BCA",
                SortDescription = "Software Engineer",
                LastApplyDate = DateTime.Now,
                UserId = 1
            });

            modelBuilder.Entity<Job>().HasData(new Job
            {
                Id = 3,
                JobCode = "JOB113",
                Title = "Tech Lead",
                MinimumQualification = "BCA",
                SortDescription = "Software Engineer",
                LastApplyDate = DateTime.Now,
                UserId = 1
            });

           
        }
    }
}
