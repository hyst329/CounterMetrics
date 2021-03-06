﻿using System;
using CounterMetrics.Contracts.Managers;
using Microsoft.Practices.Unity;

namespace CounterMetrics.ClientApp
{
    internal class Program
    {
        private static void Main()
        {
            Console.Title = "Client App";
            var container = Bootstrapper.Init();
            var accountManager = (IAccountManager) container.Resolve(typeof(IAccountManager));
            var authManager = (IAuthManager) container.Resolve(typeof(IAuthManager));
            var counterManager = (ICounterManager) container.Resolve(typeof(ICounterManager));
            var metricsManager = (IMetricsManager) container.Resolve(typeof(IMetricsManager));
            var @operator = new ConsoleOperator(accountManager, authManager, counterManager, metricsManager);
            @operator.Operate();
            Console.ReadKey();
        }
    }
}