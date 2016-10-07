using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Contracts.Managers;
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
            unityContainer.RegisterType<IAccountManager, AccountManager>(new InjectionConstructor(
                new ResolvedParameter<IUserRepository>("UserRepository")));
            unityContainer.RegisterType<IAuthManager, AuthManager>(new InjectionConstructor(
                new ResolvedParameter<IUserRepository>("UserRepository")));
            unityContainer.RegisterType<ICounterManager, CounterManager>(new InjectionConstructor(
                new ResolvedParameter<ICounterRepository>("CounterRepository")));
            unityContainer.RegisterType<IMetricsManager, MetricsManager>(new InjectionConstructor(
                new ResolvedParameter<IMetricsStoreRepository>("MetricsStoreRepository"),
                new ResolvedParameter<IMetricsRetrieveRepository>("MetricsRetrieveRepository"),
                new ResolvedParameter<IUserRepository>("UserRepository")));

            ServiceLocator.Build(unityContainer);
            return unityContainer;
        }
    }
}