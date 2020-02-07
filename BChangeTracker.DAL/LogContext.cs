using AChangeTracker.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BChangeTracker.DAL
{
    public class LogContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=FrameWorkLogDB;User Id = sa;Password = ABCabc123456;");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<DataChangeHistory> DataChangeHistory { get; set; }
    }
}
