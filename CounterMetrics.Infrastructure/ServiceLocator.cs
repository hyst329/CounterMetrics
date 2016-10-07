using Microsoft.Practices.Unity;

namespace CounterMetrics.Infrastructure
{
    public class ServiceLocator
    {
        private static ServiceLocator _serviceLocatorInstance;

        private static UnityContainer _containerIoc;

        private ServiceLocator()
        {
        }

        public static ILogger Logger
        {
            get { return _containerIoc.Resolve<ILogger>(); }
        }

        public static IHasher Hasher
        {
            get { return _containerIoc.Resolve<IHasher>(); }
        }

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