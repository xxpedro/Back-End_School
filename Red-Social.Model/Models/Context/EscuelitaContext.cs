using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Red_Social.Model.Models.Context
{
    public class EscuelitaContext : DbContext
    {
        public EscuelitaContext(DbContextOptions<EscuelitaContext> options) : base(options)
        {

        }
        public DbSet<Courses.Courses> Courses { get; set; }
        public DbSet<Teachers.Teachers> Teachers { get; set; }
        public DbSet<Students.Students> Students { get; set; }
        public DbSet<MatterAssignment.MatterAssignment> matterAssignments { get; set; }
        public DbSet<MatterSelection.MatterSelection> matterSelections { get; set; }
    }
}
