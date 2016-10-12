using System;
using System.ServiceModel;
using CounterMetrics.Contracts.Managers;
using Unity.Wcf;
using Microsoft.Practices.Unity;

namespace CounterMetrics.Host.Managers
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = Bootstrapper.Init();
            Console.Title = "Manager Host";
            var hostAccountManager = new UnityServiceHost(container, container.Resolve<IAccountManager>().GetType(), new Uri[] { });
            hostAccountManager.Open();
            PrintServiceInfo(hostAccountManager);
            var hostAuthManager = new UnityServiceHost(container, container.Resolve<IAuthManager>().GetType(), new Uri[] { });
            hostAuthManager.Open();
            PrintServiceInfo(hostAuthManager);
            var hostCounterManager = new UnityServiceHost(container, container.Resolve<ICounterManager>().GetType(), new Uri[] { });
            hostCounterManager.Open();
            PrintServiceInfo(hostCounterManager);
            var hostMetricsManager = new UnityServiceHost(container, container.Resolve<IMetricsManager>().GetType(), new Uri[] { });
            hostMetricsManager.Open();
            PrintServiceInfo(hostMetricsManager);
            Console.WriteLine("Service started {0}", DateTime.Now);
            Console.WriteLine("Please Enter...");
            Console.ReadLine();
        }

        private static void PrintServiceInfo(ServiceHost serviceHost)
        {
            Console.WriteLine("Service Name: {0}", serviceHost.Description.Name);
            Console.WriteLine("\tConfig Name: {0}", serviceHost.Description.ConfigurationName);
            foreach (var endpoint in serviceHost.Description.Endpoints)
            {
                Console.WriteLine("\tEndpoint: {0}", endpoint.Name);
                Console.WriteLine("\t\tContract: {0}", endpoint.Contract.ContractType);
                Console.WriteLine("\t\tAddress: {0}", endpoint.Address.Uri);
            }
        }
    }
}