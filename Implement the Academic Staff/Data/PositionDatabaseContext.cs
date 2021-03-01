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

        public DbSet<PositionDatabase.Models.Person> Person { get; set; }

        public DbSet<PositionDatabase.Models.Position> Position { get; set; }
       
        //
        public DbSet<PositionDatabase.Models.SalaryStep> SalaryStep { get; set; }
        public DbSet<PositionDatabase.Models.SalaryScale> SalaryScale { get; set; }
        public DbSet<PositionDatabase.Models.SalaryComponent> SalaryComponent { get; set; }
        public DbSet<PositionDatabase.Models.AdministrativeStipend> AdministrativeStipend { get; set; }
        public DbSet<PositionDatabase.Models.MarketSupplement> MarketSupplement { get; set; }
        public DbSet<PositionDatabase.Models.BaseSalary> BaseSalary { get; set; }
        //
        public DbSet<PositionDatabase.Models.AcademicStaff> AcademicStaff { get; set; }
        public DbSet<PositionDatabase.Models.ATS> ATS { get; set; }
        public DbSet<PositionDatabase.Models.APO> APO { get; set; }
        public DbSet<PositionDatabase.Models.Faculty> Faculty { get; set; }
        public DbSet<PositionDatabase.Models.FSO> FSO { get; set; }
        public DbSet<PositionDatabase.Models.Librarian> Librarian { get; set; }
        public DbSet<PositionDatabase.Models.TemporaryAPO> TemporaryAPO { get; set; }
        public DbSet<PositionDatabase.Models.TemporaryLibrarian> TemporaryLibrarian { get; set; }
        public DbSet<PositionDatabase.Models.TrustResearchAcademic> TrustResearchAcademic { get; set; }

    }
}
