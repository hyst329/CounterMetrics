﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using CounterMetrics.Contracts.DataAccess;

namespace CounterMetrics.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(string connectionString) //
            : base(connectionString)
        {
            Database.SetInitializer<DatabaseContext>(null);
        }

        //: base("name=ServerStatusConn")
        public DbSet<UserEntity> UserEntity { get; set; }
        public DbSet<CounterEntity> CounterEntity { get; set; }
        public DbSet<MetricEntity> MetricEntity { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MetricEntity>()
                .Property(m => m.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}