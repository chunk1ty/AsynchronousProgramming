
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Database
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class WebApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
           // optionsBuilder.UseSqlServer(@"Server=.;Database=WebApplicationDbContext;Trusted_Connection=True;");

            optionsBuilder.UseSqlServer(@"Server=.;Database=WebApplicationDbContext;User Id=sa;password=<YourStrong@Passw0rd>;Trusted_Connection=False;MultipleActiveResultSets=true;");
        }

        public DbSet<Student> Students { get; set; }
    }
}
