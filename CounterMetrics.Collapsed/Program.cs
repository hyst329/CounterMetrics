﻿using System;
using CounterMetrics.Contracts.Managers;
using CounterMetrics.Infrastructure;
using Microsoft.Practices.Unity;

namespace CounterMetrics.Collapsed
{
    internal class Program
    {
        private static void Main()
        {
            Console.Title = "Collapsed Client";
            var container = Bootstrapper.Init();
            var accountManager = (IAccountManager) container.Resolve(typeof(IAccountManager));
            var authManager = (IAuthManager) container.Resolve(typeof(IAuthManager));
            var counterManager = (ICounterManager) container.Resolve(typeof(ICounterManager));
            var metricsManager = (IMetricsManager) container.Resolve(typeof(IMetricsManager));
            var sessionContextHelper = (ISessionContextHelper) container.Resolve(typeof(ISessionContextHelper));
            var @operator = new ConsoleOperator(accountManager, authManager, counterManager, metricsManager,
                sessionContextHelper);
            @operator.Operate();
            Console.ReadKey();
        }
    }
}