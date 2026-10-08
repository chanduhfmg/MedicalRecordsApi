using MedicalRecordApi  .Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MedicalRecordApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<EndoscopyProcedureRecord> EndoscopyProcedureRecords { get; set; }
        public DbSet<EndoscopyPostProcedureRecord> EndoscopyPostProcedureRecords { get; set; } 
        public DbSet<AldreteScore> AldreteScores { get; set; }
        public DbSet<AssessmentMonitoringRow> AssessmentMonitoringRows { get; set; }
        public DbSet<NursingMedicationEntry> NursingMedicationEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EndoscopyProcedureRecord>()
                .Property(x => x.BotJobDone)
                .HasDefaultValue(0);

            // One-to-One
            modelBuilder.Entity<EndoscopyPostProcedureRecord>()
                .HasOne(e => e.Aldrete)
                 .WithOne()
                .HasForeignKey<AldreteScore>(a => a.EndoscopyPostProcedureRecordId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many
            modelBuilder.Entity<EndoscopyPostProcedureRecord>()
                .HasMany(e => e.MonitoringRows)
                .WithOne()
                .HasForeignKey(m => m.EndoscopyPostProcedureRecordId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EndoscopyPostProcedureRecord>()
                .HasMany(e => e.NursingMedications)
                .WithOne()
                .HasForeignKey(n => n.EndoscopyPostProcedureRecordId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}