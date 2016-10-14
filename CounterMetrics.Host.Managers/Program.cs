using System;
using System.ServiceModel;
using CounterMetrics.Contracts.Managers;
using Microsoft.Practices.Unity;
using Unity.Wcf;

namespace CounterMetrics.Host.Managers
{
    internal class Program
    {
        private static void Main()
        {
            var container = Bootstrapper.Init();
            Console.Title = "Manager Host";
            var hostAccountManager = new UnityServiceHost(container, container.Resolve<IAccountManager>().GetType());
            hostAccountManager.Open();
            PrintServiceInfo(hostAccountManager);
            var hostAuthManager = new UnityServiceHost(container, container.Resolve<IAuthManager>().GetType());
            hostAuthManager.Open();
            PrintServiceInfo(hostAuthManager);
            var hostCounterManager = new UnityServiceHost(container, container.Resolve<ICounterManager>().GetType());
            hostCounterManager.Open();
            PrintServiceInfo(hostCounterManager);
            var hostMetricsManager = new UnityServiceHost(container, container.Resolve<IMetricsManager>().GetType());
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