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
    }
}
