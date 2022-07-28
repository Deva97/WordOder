using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WorkOrder.Model;

namespace WorkOrder.Context
{
    public class WorkDbContext : DbContext
    {
        public WorkDbContext(DbContextOptions<WorkDbContext> options):
            base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkBoard>().
                HasOne<Work>(p => p.Work).
                WithMany(b => b.WorkBoardsWorkDetails).HasForeignKey(f => f.WorkId);

            modelBuilder.Entity<WorkBoard>().
                HasOne<Technician>(p => p.Technician).
                WithMany(b => b.WorkBoardsTechnicainDetails).HasForeignKey(f => f.TechnicianId);

        }

        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<WorkBoard> WorkBoards { get; set; }

    }
}
