using System;
using System.Messaging;
using System.Configuration;
using System.ServiceModel;
using CounterMetrics.Contracts.DataAccess;
using Microsoft.Practices.Unity;
using Unity.Wcf;

namespace CounterMetrics.Host.DataAccess
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = Bootstrapper.Init();
            Console.Title = "Data Access Host";
            var hostUserRepository = new UnityServiceHost(container, container.Resolve<IUserRepository>().GetType(), new Uri[] { });
            hostUserRepository.Open();
            PrintServiceInfo(hostUserRepository);
            var hostCounterRepository = new UnityServiceHost(container, container.Resolve<ICounterRepository>().GetType(), new Uri[] { });
            hostCounterRepository.Open();
            PrintServiceInfo(hostCounterRepository);
            var hostMetricsStoreRepository = new UnityServiceHost(container, container.Resolve<IMetricsStoreRepository>().GetType(), new Uri[] { });
            hostMetricsStoreRepository.Open();
            PrintServiceInfo(hostMetricsStoreRepository);
            var hostMetricsRetrieveRepository = new UnityServiceHost(container, container.Resolve<IMetricsRetrieveRepository>().GetType(), new Uri[] { });
            hostMetricsRetrieveRepository.Open();
            PrintServiceInfo(hostMetricsRetrieveRepository);
            var hostSessionContextRepository = new UnityServiceHost(container, container.Resolve<ISessionContextRepository>().GetType(), new Uri[] { });
            hostSessionContextRepository.Open();
            PrintServiceInfo(hostSessionContextRepository);
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