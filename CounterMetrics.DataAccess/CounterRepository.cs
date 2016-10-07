using System;
using System.Linq;
using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Infrastructure;

namespace CounterMetrics.DataAccess
{
    public class CounterRepository : ICounterRepository
    {
        private readonly DatabaseContext _databaseContext;

        public CounterRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Create(CounterEntity counterEntity)
        {
            //throw new NotImplementedException();
            try
            {
                ServiceLocator.Logger.Log(LogSeverity.Info, $"DataAccess {GetType().FullName}: Create");
                _databaseContext.CounterEntity.Add(counterEntity);
                _databaseContext.SaveChanges();
            }
            catch (Exception e)
            {
                ServiceLocator.Logger.Log(LogSeverity.Error, e.Message);
                throw;
            }
            ServiceLocator.Logger.Log(LogSeverity.Info,
                $"Created counter of type {counterEntity.Type} with ID {counterEntity.Id}");
        }

        public void DeleteById(int counterId)
        {
            //throw new NotImplementedException();
            CounterEntity counterEntity;
            try
            {
                counterEntity = _databaseContext.CounterEntity.First(counter => counter.Id == counterId);
                ServiceLocator.Logger.Log(LogSeverity.Info, $"DataAccess {GetType().FullName}: Delete");
                _databaseContext.CounterEntity.Remove(counterEntity);
                _databaseContext.SaveChanges();
            }
            catch (Exception e)
            {
                ServiceLocator.Logger.Log(LogSeverity.Error, e.Message);
                throw;
            }
            ServiceLocator.Logger.Log(LogSeverity.Info,
                $"Deleted counter {counterEntity.Type} of type with ID {counterEntity.Id}");
        }

        public CounterEntity FindById(int counterId)
        {
            //throw new NotImplementedException();
            CounterEntity counterEntity;
            try
            {
                counterEntity = _databaseContext.CounterEntity.First(counter => counter.Id == counterId);
                ServiceLocator.Logger.Log(LogSeverity.Info,
                    $"DataAccess {GetType().FullName}: FindAll by ID");
            }
            catch (Exception e)
            {
                ServiceLocator.Logger.Log(LogSeverity.Error, e.Message);
                throw;
            }
            return counterEntity;
        }

        public CounterEntity[] FindByUserId(int userId, CounterType? counterType)
        {
            //throw new NotImplementedException();
            try
            {
                var counterEntities =
                    _databaseContext.CounterEntity.Where(counter => counter.UserId == userId).ToArray();
                ServiceLocator.Logger.Log(LogSeverity.Info,
                    $"DataAccess {GetType().FullName}: FindAll by User ID");
                return counterEntities;
            }
            catch (Exception e)
            {
                ServiceLocator.Logger.Log(LogSeverity.Error, e.Message);
                throw;
            }
        }

        public CounterEntity[] FindAll()
        {
            try
            {
                ServiceLocator.Logger.Log(LogSeverity.Info,
                    $"DataAccess {GetType().FullName}: FindAll All");
                return _databaseContext.CounterEntity.ToArray();
            }
            catch (Exception e)
            {
                ServiceLocator.Logger.Log(LogSeverity.Error, e.Message);
                throw;
            }
        }
    }
}