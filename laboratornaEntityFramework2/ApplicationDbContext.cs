using System;
using laboratorna.Model;
using Microsoft.EntityFrameworkCore;

namespace laboratorna.Data
{
    public class ApplicationDbContext : DbContext
    {
        //public Context()
        //{
        //   Database.CanConnect();
        //   Database.EnsureCreated();
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-37D15EC\MSSQLSERVERLABA;Database=test4;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<TeacherEntity> Teachers { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<GradeEntity> Grades { get; set; }

    }
}
