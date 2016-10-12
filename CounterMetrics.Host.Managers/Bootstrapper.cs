using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Contracts.Managers;
using CounterMetrics.DataAccess;
using CounterMetrics.Infrastructure;
using CounterMetrics.Managers;
using Microsoft.Practices.Unity;

namespace CounterMetrics.Host.Managers
{
    internal class Bootstrapper
    {
        public static UnityContainer Init()
        {
            var unityContainer = new UnityContainer();
            unityContainer.RegisterType<ILogger, Logger>();
            unityContainer.RegisterType<IHasher, Hasher>();
            unityContainer.RegisterType<IUserRepository, UserRepository>();
            unityContainer.RegisterType<ICounterRepository, CounterRepository>();
            unityContainer.RegisterInstance<ISessionContextRepository>(
                unityContainer.Resolve<SessionContextRepository>());
            unityContainer.RegisterType<IMetricsStoreRepository, MetricsStoreRepository>();
            unityContainer.RegisterType<IMetricsRetrieveRepository, MetricsRetrieveRepository>();
            unityContainer.RegisterType<IUserRepository, UserRepository>();
            unityContainer.RegisterType<ISessionContextHelper, WcfSessionContextHelper>();
            unityContainer.RegisterType<IAccountManager, AccountManager>(new InjectionConstructor(
                new ResolvedParameter<IUserRepository>(), new ResolvedParameter<IHasher>()));
            unityContainer.RegisterType<IAuthManager, AuthManager>(new InjectionConstructor(
                new ResolvedParameter<IUserRepository>(), new ResolvedParameter<ISessionContextRepository>(),
                new ResolvedParameter<ISessionContextHelper>(), new ResolvedParameter<IHasher>()));
            unityContainer.RegisterType<ICounterManager, CounterManager>(new InjectionConstructor(
                new ResolvedParameter<ICounterRepository>(), new ResolvedParameter<ISessionContextRepository>(),
                new ResolvedParameter<ISessionContextHelper>()));
            unityContainer.RegisterType<IMetricsManager, MetricsManager>(new InjectionConstructor(
                new ResolvedParameter<IMetricsStoreRepository>(),
                new ResolvedParameter<IMetricsRetrieveRepository>(),
                new ResolvedParameter<IUserRepository>(), new ResolvedParameter<ISessionContextRepository>(),
                new ResolvedParameter<ISessionContextHelper>()));


            ServiceLocator.Build(unityContainer);
            return unityContainer;
        }
    }
}