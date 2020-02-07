using AChangeTracker.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BChangeTracker.DAL
{
   public class TeacherContext: BaseDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=FrameWorkDB;User Id = sa;Password = ABCabc123456;");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Teachers> Teachers { get; set; }
    }
}
