using System;
using System.Linq;
using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Infrastructure;

namespace CounterMetrics.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext databaseContext;

        public UserRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Create(UserEntity userEntity)
        {
            //throw new NotImplementedException();
            try
            {
                ServiceLocator.Logger.Log(LogSeverity.Info, string.Format("DataAccess {0}: Create", GetType().FullName));
                databaseContext.UserEntity.Add(userEntity);
                databaseContext.SaveChanges();
            }
            catch (Exception e)
            {
                ServiceLocator.Logger.Log(LogSeverity.Error, e.Message);
                throw;
            }
            ServiceLocator.Logger.Log(LogSeverity.Info,
                string.Format("Created user {0} with ID {1} and password hash {2}", userEntity.Name,
                    userEntity.ID, userEntity.PasswordHash));
        }

        public void DeleteByID(int userID)
        {
            UserEntity userEntity;
            try
            {
                ServiceLocator.Logger.Log(LogSeverity.Info, string.Format("DataAccess {0}: Delete", GetType().FullName));
                userEntity = databaseContext.UserEntity.First(uE => uE.ID == userID);
                databaseContext.UserEntity.Remove(userEntity);
                databaseContext.SaveChanges();
            }
            catch (Exception e)
            {
                ServiceLocator.Logger.Log(LogSeverity.Error, e.Message);
                throw;
            }
            ServiceLocator.Logger.Log(LogSeverity.Info, string.Format("Deleted user {0} with ID {1}", userEntity.Name,
                userEntity.ID));
        }

        public UserEntity[] Find()
        {
            //throw new NotImplementedException();
            try
            {
                ServiceLocator.Logger.Log(LogSeverity.Info,
                    string.Format("DataAccess {0}: Find all", GetType().FullName));
                return databaseContext.UserEntity.ToArray();
            }
            catch (Exception e)
            {
                ServiceLocator.Logger.Log(LogSeverity.Error, e.Message);
                throw;
            }
        }

        public UserEntity FindByID(int userID)
        {
            //throw new NotImplementedException();
            try
            {
                ServiceLocator.Logger.Log(LogSeverity.Info,
                    string.Format("DataAccess {0}: Find by ID", GetType().FullName));
                return databaseContext.UserEntity.First(uE => uE.ID == userID);
            }
            catch (Exception e)
            {
                ServiceLocator.Logger.Log(LogSeverity.Error, e.Message);
                throw;
            }
        }

        public int GetFreeID()
        {
            //throw new NotImplementedException();
            int id;
            try
            {
                ServiceLocator.Logger.Log(LogSeverity.Info,
                    string.Format("DataAccess {0}: Get Free ID", GetType().FullName));
                id = databaseContext.UserEntity.Select(user => user.ID).DefaultIfEmpty(0).Max() + 1;
            }

            catch (Exception e)
            {
                ServiceLocator.Logger.Log(LogSeverity.Error, e.Message);
                throw;
            }
            ServiceLocator.Logger.Log(LogSeverity.Info, string.Format("Free ID is {0}", id));
            return id;
        }
    }
}