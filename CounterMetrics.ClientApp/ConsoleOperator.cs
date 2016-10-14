using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Contracts.Managers;

namespace CounterMetrics.ClientApp
{
    public class ConsoleOperator
    {
        public delegate void MenuMethod();

        private readonly IAccountManager _accountManager;
        private readonly IAuthManager _authManager;
        private readonly IMetricsManager _metricsManager;
        private readonly ICounterManager _counterManager;
        private readonly Dictionary<int, string> _menu;
        private readonly Dictionary<int, MenuMethod> _menuFunctions;
        private readonly Dictionary<int, string> _menuLogon;
        private readonly Dictionary<int, MenuMethod> _menuLogonFunctions;

        private bool _shouldExit;
        private LoginData _token;

        public ConsoleOperator(IAccountManager accountManager, IAuthManager authManager, ICounterManager counterManager,
            IMetricsManager metricsManager)
        {
            _accountManager = accountManager;
            _authManager = authManager;
            _counterManager = counterManager;
            _metricsManager = metricsManager;

            _menu = new Dictionary<int, string>
            {
                {1, "Add a metric"},
                {2, "Show statistics by date"},
                {3, "Show statistics by type"},
                {4, "Add a counter (ADMIN ONLY)"},
                {5, "Show stats for all users (ADMIN ONLY)"},
                {6, "Show all yor stats"},
                {7, "Log out"},
                {8, "Exit"}
            };
            _menuFunctions = new Dictionary<int, MenuMethod>
            {
                {1, AddMetric},
                {2, ShowStatsByDate},
                {3, ShowStatsByType},
                {4, AddCounter},
                {5, ShowAllStats},
                {6, ShowAllStatsForUser},
                {7, Logout},
                {8, Exit}
            };
            _menuLogon = new Dictionary<int, string>
            {
                {1, "Log in"},
                {2, "Register"},
                {3, "Exit"}
            };
            _menuLogonFunctions = new Dictionary<int, MenuMethod>
            {
                {1, Login},
                {2, Register},
                {3, Exit}
            };
            _token = null;
            _shouldExit = false;
        }

        public void Operate()
        {
            while (!_shouldExit)
            {
                var menu = _token != null ? _menu : _menuLogon;
                var menuFunctions = _token != null ? _menuFunctions : _menuLogonFunctions;
                var choice = 0;
                ShowMenu(menu);
                while (!menu.ContainsKey(choice))
                {
                    Console.Write("Enter your choice: ");
                    var line = Console.ReadLine();
                    if (!int.TryParse(line, out choice)) choice = 0;
                }
                menuFunctions[choice]();
            }
        }

        private void ShowAllStatsForUser()
        {
            try
            {
                var res = _metricsManager.FindByType(null);
                ShowMetrics(res);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error occured: {0}.", exception.Message);
            }
        }

        private void AddCounter()
        {
            //throw new NotImplementedException();
            if (!CheckForAdmin())
            {
                Console.WriteLine("You must log in as administrator to complete this action.");
                return;
            }
            try
            {
                Console.Write("Enter new counter ID: ");
                var idstr = Console.ReadLine() ?? "";
                var counterId = int.Parse(idstr);
                Console.Write("Enter owner ID: ");
                var uidstr = Console.ReadLine() ?? "";
                var userId = int.Parse(uidstr);
                Console.Write(
                    "Enter '0' or 'Water' to add a water counter, or '1' or 'Electricity' to ad an electricity one: ");
                var tp = Console.ReadLine() ?? "";
                var type = (CounterType) Enum.Parse(typeof(CounterType), tp);
                _counterManager.Add(new Counter {Id = counterId, UserId = userId, Type = type});
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error occured: {0}.", exception.Message);
            }
        }

        private void AddMetric()
        {
            //throw new NotImplementedException();
            try
            {
                var counters = _counterManager.FindOwned(null);
                Console.Write("Enter counter ID ");
                Console.Write("[");
                foreach (var counter in counters)
                {
                    Console.Write("{0} ", counter.Id);
                }
                Console.Write("]:");
                var idstr = Console.ReadLine() ?? "";
                var counterId = int.Parse(idstr);
                
                if (
                    counters
                        .Count(counter => counter.Id == counterId) == 0)
                {
                    Console.WriteLine("Counter not found or not owned by logged-in user");
                    return;
                }
                Console.Write("Enter metric value: ");
                var mvstr = Console.ReadLine() ?? "";
                var metricValue = decimal.Parse(mvstr);
                _metricsManager.Add(new Metric
                {
                    CounterId = counterId,
                    MetricDate = DateTime.Now,
                    MetricValue = metricValue
                });
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error occured: {0}.", exception.Message);
            }
        }

        public void Login()
        {
            Console.Write("Username: ");
            var username = Console.ReadLine();
            Console.Write("Password: ");
            var password = GetConsoleSecurePassword();
            _token = _authManager.Login(new User {Name = username, Password = password});
            if (_token == null)
                Console.WriteLine("Cannot log in username and/or password may be incorrect");
            else
            {
                Console.WriteLine("Login successful, user ID {0}", _token.UserId);
                //_sessionContextHelper.Instance.SessionGuid = _token.SessionGuid;
                //_sessionContextHelper.Instance.UserId = _token.UserId;
            }
        }

        public void Logout()
        {
            _token = null;
            //_sessionContextHelper.Instance.SessionGuid = Guid.Empty;
            Console.WriteLine();
        }

        public void Register()
        {
            Console.Write("Username for the new user: ");
            var username = Console.ReadLine();
            Console.Write("Password for the new user: ");
            var password1 = GetConsoleSecurePassword();
            Console.Write("Repeat password: ");
            var password2 = GetConsoleSecurePassword();
            if (password1 != password2)
            {
                Console.WriteLine("Passwords do not match");
                return;
            }
            var result = _accountManager.Register(new User {Name = username, Password = password1});
            Console.WriteLine(result ? "Registration successful" : "Unable to register user, may be already present");
        }

        public void Exit()
        {
            _shouldExit = true;
        }

        public void ShowStatsByType()
        {
            Console.Write(
                "Enter '0' or 'Water' to select water counters, or '1' or 'Electricity' to select electricity ones: ");
            try
            {
                var tp = Console.ReadLine() ?? "";
                var type = (CounterType) Enum.Parse(typeof(CounterType), tp);
                var res = _metricsManager.FindByType(type);
                ShowMetrics(res);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error occured: {0}.", exception.Message);
            }
        }

        public void ShowStatsByDate()
        {
            try
            {
                Console.Write("Enter start date: ");
                var sd = Console.ReadLine();
                var start = DateTime.Parse(sd);
                Console.Write("Enter end date : ");
                var ed = Console.ReadLine();
                var end = DateTime.Parse(ed);
                var res = _metricsManager.FindByDate(start, end);
                ShowMetrics(res);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error occured: {0}.", exception.Message);
            }
        }

        public void ShowAllStats()
        {
            if (!CheckForAdmin())
            {
                Console.WriteLine("You must log in as administrator to complete this action.");
                return;
            }
            try
            {
                var res = _metricsManager.Find();
                ShowMetrics(res);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error occured: {0}.", exception.Message);
            }
        }

        #region Helper Methods

        private static string GetConsoleSecurePassword()
        {
            var pwd = new StringBuilder();
            while (true)
            {
                var i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                if (i.Key == ConsoleKey.Backspace && pwd.Length > 0)
                {
                    pwd.Remove(pwd.Length - 1, 1);
                    Console.Write("\b \b");
                }
                else
                {
                    pwd.Append(i.KeyChar);
                    Console.Write("*");
                }
            }
            return pwd.ToString();
        }

        private void ShowMenu(Dictionary<int, string> menu)
        {
            Console.WriteLine("Available actions: ");
            foreach (var item in menu)
                Console.WriteLine(item.Key + ": " + item.Value);
        }

        private void ShowMetrics(Metric[] metrics)
        {
            Console.WriteLine("METRIC DATA: ");
            if (metrics.Length == 0) Console.WriteLine("No data to display.");
            var counters = _counterManager.FindAll();
            var hLine = "".PadRight(Console.WindowWidth, '-');
            var tableFormat = "|{0,10}|{3,5}|{1,28}|{2,9} {4,5} ({5,14})|";
            Console.Write(hLine);
            Console.Write(tableFormat, "Ctr ID", "Date", "Value", "UID", "units", "type");
            Console.Write(hLine);
            foreach (var metric in metrics)
            {
                var ctrData = counters.First(counter => counter.Id == metric.CounterId);
                Console.Write(tableFormat, metric.CounterId,
                    metric.MetricDate,
                    metric.MetricValue, ctrData.UserId, GetUnits(ctrData.Type), ctrData.Type);
            }
            Console.Write(hLine);
        }

        private bool CheckForAdmin() => (_token != null) && (_token.UserId == 1);

        private string GetUnits(CounterType counterType)
        {
            switch (counterType)
            {
                case CounterType.Electricity:
                    return "kWh";
                case CounterType.Water:
                    return "m3";
                default:
                    return "units";
            }
        }

        #endregion
    }
}