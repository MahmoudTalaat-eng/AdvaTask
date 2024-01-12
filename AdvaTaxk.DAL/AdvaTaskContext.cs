using AdvaTask.Tables;
using Microsoft.EntityFrameworkCore;

namespace AdvaTask.DAL
{
    public class AdvaTaskContext : DbContext
    {
        public AdvaTaskContext(DbContextOptions<AdvaTaskContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Manager) // Employee has one Manager
                .WithMany()             // Manager can have many Employees
                .HasForeignKey(e => e.ManagerId) // Foreign key property
                .OnDelete(DeleteBehavior.Restrict); // Restrict deletion of manager if employees still reference it
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
