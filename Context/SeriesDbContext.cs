using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using NetlixRecords.Model;

namespace NetlixRecords.Context
{
    public class SeriesDbContext : DbContext
    {
        public SeriesDbContext(DbContextOptions<SeriesDbContext> options):
            base(options)
        {

        }
        public DbSet<Series> Series { get; set; }

    }
}
