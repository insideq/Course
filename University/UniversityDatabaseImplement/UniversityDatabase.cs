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
                //Возможно понадобится писать вместо (localdb) название пк, вот пк Егора:  DESKTOP-N8BRIPR
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\SQLEXPRESS;Initial Catalog=UniversityDatabaseFull;Integrated Security=True;MultipleActiveResultSets=True;;TrustServerCertificate=True");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Student> Students { set; get; }
        public virtual DbSet<PlanOfStudy> PlansOfStudy { set; get; }
        public virtual DbSet<Attestation> Attestations { set; get; }
        // public virtual DbSet<Worker> Workers { set; get; }
        public virtual DbSet<Storekeeper> Storekeepers { set; get; }
        public virtual DbSet<Teacher> Teachers { set; get; }
        public virtual DbSet<Discipline> Disciplines { set; get; }
        public virtual DbSet<Statement> Statements { set; get; }
    }
}
