using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using UniversityDatabaseImplement.Models;

namespace UniversityDatabaseImplement
{
    public class UniversityDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder
            optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Database=PlumbingRepairDatabaseFull;Username=postgres;Password=postgres");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Student> Students { set; get; }
        public virtual DbSet<PlanOfStudy> PlansOfStudy { set; get; }
        public virtual DbSet<Attestation> Attestations { set; get; }
        // public virtual DbSet<Worker> Workers { set; get; }
        // public virtual DbSet<Storekeeper> Storekeepers { set; get; }
    }
}
