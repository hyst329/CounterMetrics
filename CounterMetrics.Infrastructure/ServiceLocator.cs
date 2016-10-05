﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace CounterMetrics.Infrastructure
{
    public class ServiceLocator
    {
        private static ServiceLocator _serviceLocatorInstance = null;

        private static UnityContainer _containerIoc;

        private ServiceLocator()
        {

        }

        public static ILogger Logger { get { return _containerIoc.Resolve<ILogger>(); } }

        public static ServiceLocator Build(UnityContainer containerIoc)
        {
            if (_serviceLocatorInstance == null)
            {
                _serviceLocatorInstance = new ServiceLocator();
                _containerIoc = containerIoc;
            }

            return _serviceLocatorInstance;
        }

    }
}