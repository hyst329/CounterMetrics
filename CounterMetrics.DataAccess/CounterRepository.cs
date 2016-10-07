using System;
using System.Linq;
using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Infrastructure;

namespace CounterMetrics.DataAccess
{
    public class CounterRepository : ICounterRepository
    {
        private readonly DatabaseContext databaseContext;

        public CounterRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Create(CounterEntity counterEntity)
        {
            //throw new NotImplementedException();
            try
            {
                ServiceLocator.Logger.Log(LogSeverity.Info, string.Format("DataAccess {0}: Create", GetType().FullName));
                databaseContext.CounterEntity.Add(counterEntity);
                databaseContext.SaveChanges();
            }
            catch (Exception e)
            {
                ServiceLocator.Logger.Log(LogSeverity.Error, e.Message);
                throw;
            }
            ServiceLocator.Logger.Log(LogSeverity.Info,
                string.Format("Created counter of type {0} with ID {1}", counterEntity.Type,
                    counterEntity.ID));
        }

        public void DeleteByID(int counterID)
        {
            //throw new NotImplementedException();
            CounterEntity counterEntity;
            try
            {
                counterEntity = databaseContext.CounterEntity.First(counter => counter.ID == counterID);
                ServiceLocator.Logger.Log(LogSeverity.Info, string.Format("DataAccess {0}: Delete", GetType().FullName));
                databaseContext.CounterEntity.Remove(counterEntity);
                databaseContext.SaveChanges();
            }
            catch (Exception e)
            {
                ServiceLocator.Logger.Log(LogSeverity.Error, e.Message);
                throw;
            }
            ServiceLocator.Logger.Log(LogSeverity.Info,
                string.Format("Deleted counter {0} of type with ID {1}", counterEntity.Type,
                    counterEntity.ID));
        }

        public CounterEntity FindByID(int counterID)
        {
            //throw new NotImplementedException();
            CounterEntity counterEntity;
            try
            {
                counterEntity = databaseContext.CounterEntity.First(counter => counter.ID == counterID);
                ServiceLocator.Logger.Log(LogSeverity.Info,
                    string.Format("DataAccess {0}: Find by ID", GetType().FullName));
            }
            catch (Exception e)
            {
                ServiceLocator.Logger.Log(LogSeverity.Error, e.Message);
                throw;
            }
            return counterEntity;
        }

        public CounterEntity[] FindByUserID(int userID)
        {
            //throw new NotImplementedException();
            try
            {
                var counterEntities = databaseContext.CounterEntity.Where(counter => counter.UserID == userID).ToArray();
                ServiceLocator.Logger.Log(LogSeverity.Info,
                    string.Format("DataAccess {0}: Find by User ID", GetType().FullName));
                return counterEntities;
            }
            catch (Exception e)
            {
                ServiceLocator.Logger.Log(LogSeverity.Error, e.Message);
                throw;
            }
        }
    }
}