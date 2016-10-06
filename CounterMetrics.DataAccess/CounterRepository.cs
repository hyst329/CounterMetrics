using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterMetrics.DataAccess
{
    public class CounterRepository : ICounterRepository
    {
        private DatabaseContext databaseContext;

        public CounterRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Create(CounterEntity counterEntity)
        {
            //throw new NotImplementedException();
            try
            {
                ServiceLocator.Logger.Log(LogSeverity.Info, String.Format("DataAccess {0}: Create", this.GetType().FullName));
                this.databaseContext.CounterEntity.Add(counterEntity);
                this.databaseContext.SaveChanges();
            }
            catch (Exception e)
            {
                ServiceLocator.Logger.Log(LogSeverity.Error, e.Message);
                throw;
            }
            ServiceLocator.Logger.Log(LogSeverity.Info, String.Format("Created counter of type {0} with ID {1}", counterEntity.Type,
                counterEntity.ID));
        }
        public void Delete(CounterEntity counterEntity)
        {
            try
            {
                ServiceLocator.Logger.Log(LogSeverity.Info, String.Format("DataAccess {0}: Delete", this.GetType().FullName));
                this.databaseContext.CounterEntity.Remove(counterEntity);
                this.databaseContext.SaveChanges();
            }
            catch (Exception e)
            {
                ServiceLocator.Logger.Log(LogSeverity.Error, e.Message);
                throw;
            }
            ServiceLocator.Logger.Log(LogSeverity.Info, String.Format("Deleted counter {0} of type with ID {1}", counterEntity.Type,
                counterEntity.ID));
        }
    }
}
