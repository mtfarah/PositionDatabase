using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PositionDatabase.Models;

namespace PositionDatabase.Data
{
    public class PositionDatabaseContext : DbContext
    {
        public PositionDatabaseContext (DbContextOptions<PositionDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<SalaryScale> SalaryScales { get; set; }

        public DbSet<PositionSalaryScale> PositionSalaryScales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PositionSalaryScale>()
                .HasKey(pss => new { pss.PositionId, pss.SalaryScaleId });

            modelBuilder.Entity<PositionSalaryScale>()
                .HasOne(pss => pss.Position)
                .WithMany(p => p.PositionSalaryScales)
                .HasForeignKey(pss => pss.PositionId);

            modelBuilder.Entity<PositionSalaryScale>()
                .HasOne(pss => pss.SalaryScale)
                .WithMany(ss => ss.PositionSalaryScales)
                .HasForeignKey(pss => pss.SalaryScaleId);
        }
    }
}
