using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Unity.Wcf;

namespace CounterMetrics.Host.DataAccess
{
    public class WcfServiceFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
            container.LoadConfiguration();
            //UnityConfig.RegisterTypes(container);
        }
    }
}