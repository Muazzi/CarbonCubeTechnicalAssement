using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DLL.Models;
using Microsoft.EntityFrameworkCore;

namespace DLL.DBContext
{
    public class ApplicationDbContext : DbContext
    {

      
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedicalClaim> MedicalClaims { get; set; }
        //public DbSet<Course> Courses { get; set; }
        //public DbSet<CourseStudent> CourseStudents { get; set; }

      

    }
}
