using CounterMetrics.ClientProxies.DataAccess;
using CounterMetrics.ClientProxies.Managers;
using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Contracts.Managers;
using CounterMetrics.Infrastructure;
using Microsoft.Practices.Unity;

namespace CounterMetrics.ClientApp
{
    internal class Bootstrapper
    {
        public static UnityContainer Init()
        {
            var unityContainer = new UnityContainer();
            unityContainer.RegisterType<ILogger, Logger>();
            unityContainer.RegisterType<IHasher, Hasher>();
            unityContainer.RegisterType<IUserRepository, UserRepositoryClientProxy>();
            unityContainer.RegisterType<ICounterRepository, CounterRepositoryClientProxy>();
            unityContainer.RegisterType<IMetricsStoreRepository, MetricsStoreRepositoryClientProxy>();
            unityContainer.RegisterType<IMetricsRetrieveRepository, MetricsRetrieveRepositoryClientProxy>();
            unityContainer.RegisterType<IUserRepository, UserRepositoryClientProxy>();
            unityContainer.RegisterType<ISessionContextHelper, NoWcfSessionContextHelper>();
            unityContainer.RegisterType<IAccountManager, AccountManagerClientProxy>();
            unityContainer.RegisterType<IAuthManager, AuthManagerClientProxy>();
            unityContainer.RegisterType<ICounterManager, CounterManagerClientProxy>();
            unityContainer.RegisterType<IMetricsManager, MetricsManagerClientProxy>();

            ServiceLocator.Build(unityContainer);
            return unityContainer;
        }
    }
}