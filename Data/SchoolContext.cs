﻿using System;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().Property(m => m.ID).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<StudentFirstChild>().Property(m => m.Id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<StudentSecondChild>().Property(m => m.Id).HasDefaultValueSql("NEWSEQUENTIALID()");
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