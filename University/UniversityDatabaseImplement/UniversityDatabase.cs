﻿using Microsoft.EntityFrameworkCore;
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
                //Возможно понадобится писать вместо (localdb) название пк, вот пк Егора:  DESKTOP-N8BRIPR; other-name: LAPTOP-DYCTATOR
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\UniversityDatabase;Initial Catalog=UniversityDatabaseFull;Integrated Security=True;MultipleActiveResultSets=True;;TrustServerCertificate=True");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Student> Students { set; get; }
        public virtual DbSet<PlanOfStudy> PlanOfStudys { set; get; }
        public virtual DbSet<Attestation> Attestations { set; get; }
        public virtual DbSet<Worker> Workers { set; get; }
        public virtual DbSet<Storekeeper> Storekeepers { set; get; }
        public virtual DbSet<Teacher> Teachers { set; get; }
        public virtual DbSet<Discipline> Disciplines { set; get; }
        public virtual DbSet<Statement> Statements { set; get; }
        public virtual DbSet<StudentDiscipline> StudentDisciplines { set; get; }
        public virtual DbSet<PlanOfStudyTeacher> PlanOfStudyTeachers { set; get; }
    }
}
