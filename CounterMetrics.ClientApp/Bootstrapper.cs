using CounterMetrics.ClientProxies.Managers;
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
            unityContainer.RegisterType<ISessionContextHelper, WcfSessionContextHelper>();
            unityContainer.RegisterType<IAccountManager, AccountManagerClientProxy>();
            unityContainer.RegisterType<IAuthManager, AuthManagerClientProxy>();
            unityContainer.RegisterType<ICounterManager, CounterManagerClientProxy>();
            unityContainer.RegisterType<IMetricsManager, MetricsManagerClientProxy>();

            ServiceLocator.Build(unityContainer);
            return unityContainer;
        }
    }
}