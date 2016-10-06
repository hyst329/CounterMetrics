using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterMetrics.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private DatabaseContext databaseContext;

        public UserRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Create(UserEntity userEntity)
        {
            //throw new NotImplementedException();
            try
            {
                ServiceLocator.Logger.Log(LogSeverity.Info, String.Format("DataAccess {0}: Create", this.GetType().FullName));
                this.databaseContext.UserEntity.Add(userEntity);
                this.databaseContext.SaveChanges();
            }
            catch (Exception e)
            {
                ServiceLocator.Logger.Log(LogSeverity.Error, e.Message);
                throw;
            }
            ServiceLocator.Logger.Log(LogSeverity.Info, String.Format("Created user {0} with ID {1} and password hash {2}", userEntity.Name,
                userEntity.ID, userEntity.PasswordHash));
        }
        public void DeleteByID(int userID)
        {
            UserEntity userEntity;
            try
            {
                ServiceLocator.Logger.Log(LogSeverity.Info, String.Format("DataAccess {0}: Delete", this.GetType().FullName));
                userEntity = this.databaseContext.UserEntity.First(uE => uE.ID == userID);
                this.databaseContext.UserEntity.Remove(userEntity);
                this.databaseContext.SaveChanges();
            }
            catch (Exception e)
            {
                ServiceLocator.Logger.Log(LogSeverity.Error, e.Message);
                throw;
            }
            ServiceLocator.Logger.Log(LogSeverity.Info, String.Format("Deleted user {0} with ID {1}", userEntity.Name,
                userEntity.ID));
        }

        public int GetFreeID()
        {
            //throw new NotImplementedException();
            int id;
            try
            {
                ServiceLocator.Logger.Log(LogSeverity.Info, String.Format("DataAccess {0}: Get Free ID", this.GetType().FullName));
                id =  this.databaseContext.UserEntity.Select(user => user.ID).DefaultIfEmpty(0).Max() + 1;
            }

            catch (Exception e)
            {
                ServiceLocator.Logger.Log(LogSeverity.Error, e.Message);
                throw;
            }
            ServiceLocator.Logger.Log(LogSeverity.Info, String.Format("Free ID is {0}", id));
            return id;
        }
    }
}
