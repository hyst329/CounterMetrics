using CounterMetrics.Contracts.Managers;

namespace CounterMetrics.Collapsed
{
    internal class ConsoleOperator
    {
        private IAccountManager _accountManager;
        private IAuthManager _authManager;
        private ICounterManager _counterManager;
        private IMetricsManager _metricsManager;

        public ConsoleOperator(IAccountManager accountManager, IAuthManager authManager, ICounterManager counterManager,
            IMetricsManager metricsManager)
        {
            _accountManager = accountManager;
            _authManager = authManager;
            _counterManager = counterManager;
            _metricsManager = metricsManager;
        }
    }
}