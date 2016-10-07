using System;
using System.Linq;
using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Infrastructure;

namespace CounterMetrics.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;

        public UserRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Create(UserEntity userEntity)
        {
            //throw new NotImplementedException();
            try
            {
                ServiceLocator.Logger.Log(LogSeverity.Info, $"DataAccess {GetType().FullName}: Create");
                _databaseContext.UserEntity.Add(userEntity);
                _databaseContext.SaveChanges();
            }
            catch (Exception e)
            {
                ServiceLocator.Logger.Log(LogSeverity.Error, e.Message);
                throw;
            }
            ServiceLocator.Logger.Log(LogSeverity.Info,
                $"Created user {userEntity.Name} with ID {userEntity.Id} and password hash {userEntity.PasswordHash}");
        }

        public void DeleteById(int userId)
        {
            UserEntity userEntity;
            try
            {
                ServiceLocator.Logger.Log(LogSeverity.Info, $"DataAccess {GetType().FullName}: Delete");
                userEntity = _databaseContext.UserEntity.First(uE => uE.Id == userId);
                _databaseContext.UserEntity.Remove(userEntity);
                _databaseContext.SaveChanges();
            }
            catch (Exception e)
            {
                ServiceLocator.Logger.Log(LogSeverity.Error, e.Message);
                throw;
            }
            ServiceLocator.Logger.Log(LogSeverity.Info, $"Deleted user {userEntity.Name} with ID {userEntity.Id}");
        }

        public UserEntity[] Find()
        {
            //throw new NotImplementedException();
            try
            {
                ServiceLocator.Logger.Log(LogSeverity.Info,
                    $"DataAccess {GetType().FullName}: FindAll all");
                return _databaseContext.UserEntity.ToArray();
            }
            catch (Exception e)
            {
                ServiceLocator.Logger.Log(LogSeverity.Error, e.Message);
                throw;
            }
        }

        public UserEntity FindById(int userId)
        {
            //throw new NotImplementedException();
            try
            {
                ServiceLocator.Logger.Log(LogSeverity.Info,
                    $"DataAccess {GetType().FullName}: FindAll by ID");
                return _databaseContext.UserEntity.First(uE => uE.Id == userId);
            }
            catch (Exception e)
            {
                ServiceLocator.Logger.Log(LogSeverity.Error, e.Message);
                throw;
            }
        }

        public int GetFreeId()
        {
            //throw new NotImplementedException();
            int id;
            try
            {
                ServiceLocator.Logger.Log(LogSeverity.Info,
                    $"DataAccess {GetType().FullName}: Get Free ID");
                id = _databaseContext.UserEntity.Select(user => user.Id).DefaultIfEmpty(0).Max() + 1;
            }

            catch (Exception e)
            {
                ServiceLocator.Logger.Log(LogSeverity.Error, e.Message);
                throw;
            }
            ServiceLocator.Logger.Log(LogSeverity.Info, $"Free ID is {id}");
            return id;
        }
    }
}