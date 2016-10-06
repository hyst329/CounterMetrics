using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CounterMetrics.Contracts.DataAccess;

namespace CounterMetrics.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(string connectionString)//
           : base(connectionString)
        {
            Database.SetInitializer<DatabaseContext>(null);
        }
        //: base("name=ServerStatusConn")
        public DbSet<UserEntity> UserEntity { get; set; }
        public DbSet<CounterEntity> CounterEntity { get; set; }
        public DbSet<MetricEntity> MetricEntity { get; set; }
    }
}
