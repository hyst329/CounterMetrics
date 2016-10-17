using System.Data.Entity;
using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Contracts.Managers;
using CounterMetrics.Infrastructure;
using CounterMetrics.Managers;
using Microsoft.Practices.Unity;
using CounterMetrics.ClientProxies.DataAccess;

namespace CounterMetrics.Host.Managers
{
    internal class Bootstrapper
    {
        public static UnityContainer Init()
        {
            var unityContainer = new UnityContainer();
            unityContainer.RegisterType<ILogger, Logger>();
            unityContainer.RegisterType<IHasher, Hasher>();
            //unityContainer.RegisterType<DbContext, DatabaseContext>(new InjectionConstructor("name=CounterMetricsConn"));
            unityContainer.RegisterType<IUserRepository, UserRepositoryClientProxy>();
            unityContainer.RegisterType<ICounterRepository, CounterRepositoryClientProxy>();
            //unityContainer.RegisterInstance<ISessionContextRepository>(
            //    unityContainer.Resolve<SessionContextRepositoryClientProxy>());
            unityContainer.RegisterType<ISessionContextRepository, SessionContextRepositoryClientProxy>();
            unityContainer.RegisterType<IMetricsStoreRepository, MetricsStoreRepositoryClientProxy>();
            unityContainer.RegisterType<IMetricsRetrieveRepository, MetricsRetrieveRepositoryClientProxy>();
            unityContainer.RegisterType<IUserRepository, UserRepositoryClientProxy>();
            unityContainer.RegisterType<ISessionContextHelper, WcfSessionContextHelper>();
            unityContainer.RegisterType<IAccountManager, AccountManager>(new InjectionConstructor(
                new ResolvedParameter<IUserRepository>(), new ResolvedParameter<IHasher>()));
            unityContainer.RegisterType<IAuthManager, AuthManager>(new InjectionConstructor(
                new ResolvedParameter<IUserRepository>(), new ResolvedParameter<ISessionContextRepository>(),
                new ResolvedParameter<ISessionContextHelper>(), new ResolvedParameter<IHasher>()));
            unityContainer.RegisterType<ICounterManager, CounterManager>(new InjectionConstructor(
                new ResolvedParameter<ICounterRepository>(),
                new ResolvedParameter<IUserRepository>(),
                new ResolvedParameter<ISessionContextHelper>()));
            unityContainer.RegisterType<IMetricsManager, MetricsManager>(new InjectionConstructor(
                new ResolvedParameter<IMetricsStoreRepository>(),
                new ResolvedParameter<IMetricsRetrieveRepository>(),
                new ResolvedParameter<IUserRepository>(), 
                new ResolvedParameter<ISessionContextHelper>()));


            ServiceLocator.Build(unityContainer);
            return unityContainer;
        }
    }
}