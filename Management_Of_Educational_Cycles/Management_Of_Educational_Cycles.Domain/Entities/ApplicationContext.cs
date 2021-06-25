using Management_Of_Educational_Cycles.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Entities
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<AcademicGroup> AcademicGroups { get; set; }
        public DbSet<MixedGroup> MixedGroups { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<EducationalCycle> EducationalCycles { get; set; }
        public DbSet<WorkManagementCycle> WorkManagementCycles { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
