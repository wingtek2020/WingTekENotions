using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TekENotions.API.Models;

namespace TekENotions.API.Data
{
    public class TekENotionsContext: DbContext
    {
        public TekENotionsContext(DbContextOptions<TekENotionsContext> options): base(options)
        {

        }

        public DbSet<InspiredPatterns> InspiredPatterns { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
