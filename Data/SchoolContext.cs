using System;
using System.Runtime.CompilerServices;
using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ConsoleApp1.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<StudentFirstChild> StudentFirstChildren { get; set; }
        public DbSet<StudentSecondChild> StudentSecondChildren { get; set; }
        public DbSet<SupportedItem> SupportedItems { get; set; }
        public DbSet<TemplateItem> TemplateItems { get; set; }
        public DbSet<FeatureMapping> FeatureMappings { get; set; }
        public DbSet<Platform> Platforms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().Property(m => m.ID).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<StudentFirstChild>().Property(m => m.Id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<StudentSecondChild>().Property(m => m.Id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<SupportedItem>().Property(m => m.Id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TemplateItem>().Property(m => m.Id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<Platform>().Property(m => m.Id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<SupportedItem>().ToTable("tblSupportedItem");
            modelBuilder.Entity<Platform>().ToTable("tblPlatform");
            modelBuilder.Entity<FeatureMapping>().HasKey(m => new {m.FeatureId, m.TemplateItemId});
            modelBuilder.Entity<FeatureMapping>()
                .HasOne(m => m.FeatureItem)
                .WithMany(m => m.FeatureMappings)
                .HasForeignKey(m => m.TemplateItemId);
            modelBuilder.Entity<FeatureMapping>()
                .HasOne(m => m.TemplateItem)
                .WithMany(m => m.FeatureMappings)
                .HasForeignKey(m => m.FeatureId);
        }

        public override int SaveChanges()
        {
            foreach (var entityEntry in ChangeTracker.Entries())
            {
                if (entityEntry.State == EntityState.Modified)
                {
                    switch (entityEntry.Entity)
                    {
                        case Student student:
                            student.UpdatedDate = DateTime.Now;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}