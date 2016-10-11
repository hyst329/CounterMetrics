using System.Data.Entity;
using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Contracts.Managers;
using CounterMetrics.DataAccess;
using CounterMetrics.Infrastructure;
using CounterMetrics.Managers;
using Microsoft.Practices.Unity;

namespace CounterMetrics.Collapsed
{
    internal class Bootstrapper
    {
        public static UnityContainer Init()
        {
            var unityContainer = new UnityContainer();
            unityContainer.RegisterType<ILogger, Logger>();
            unityContainer.RegisterType<IHasher, Hasher>();
            unityContainer.RegisterType<DbContext, DatabaseContext>(new InjectionConstructor("name=CounterMetricsConn"));
            unityContainer.RegisterType<IUserRepository, UserRepository>();
            unityContainer.RegisterType<ICounterRepository, CounterRepository>();
            unityContainer.RegisterInstance<ISessionContextRepository>(unityContainer.Resolve<SessionContextRepository>());
            unityContainer.RegisterType<IMetricsStoreRepository, MetricsStoreRepository>();
            unityContainer.RegisterType<IMetricsRetrieveRepository, MetricsRetrieveRepository>();
            unityContainer.RegisterType<IUserRepository, UserRepository>();
            unityContainer.RegisterType<IAccountManager, AccountManager>(new InjectionConstructor(
                new ResolvedParameter<IUserRepository>(), new ResolvedParameter<IHasher>()));
            unityContainer.RegisterType<IAuthManager, AuthManager>(new InjectionConstructor(
                new ResolvedParameter<IUserRepository>(),  new ResolvedParameter<ISessionContextRepository>(), new ResolvedParameter<IHasher>()));
            unityContainer.RegisterType<ICounterManager, CounterManager>(new InjectionConstructor(
                new ResolvedParameter<ICounterRepository>(), new ResolvedParameter<ISessionContextRepository>()));
            unityContainer.RegisterType<IMetricsManager, MetricsManager>(new InjectionConstructor(
                new ResolvedParameter<IMetricsStoreRepository>(),
                new ResolvedParameter<IMetricsRetrieveRepository>(),
                new ResolvedParameter<IUserRepository>(), new ResolvedParameter<ISessionContextRepository>()));

            ServiceLocator.Build(unityContainer);
            return unityContainer;
        }
    }
}