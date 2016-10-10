using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Contracts.Managers;

namespace CounterMetrics.Collapsed
{
    internal class ConsoleOperator
    {
        private IAccountManager _accountManager;
        private IAuthManager _authManager;
        private ICounterManager _counterManager;
        private IMetricsManager _metricsManager;

        public delegate void MenuMethod();

        private bool _shouldExit = false;
        private Dictionary<int, string> _menu;
        private Dictionary<int, MenuMethod> _menuFunctions;
        private Dictionary<int, string> _menuLogon;
        private Dictionary<int, MenuMethod> _menuLogonFunctions;
        private LoginData? _token;

        public ConsoleOperator(IAccountManager accountManager, IAuthManager authManager, ICounterManager counterManager,
            IMetricsManager metricsManager)
        {
            _accountManager = accountManager;
            _authManager = authManager;
            _counterManager = counterManager;
            _metricsManager = metricsManager;

            _menu = new Dictionary<int, string>
            {
                {1, "Add a metric" },
                {2, "Show statistics by date" },
                {3, "Show statistics by type" },
                {4, "Add a counter (ADMIN ONLY)" },
                {5, "Show stats for all users (ADMIN ONLY)"},
                {6, "Show all yor stats"},
                {7, "Log out"},
                {8, "Exit"}
            };
            _menuLogon = new Dictionary<int, string>
            {
                {1, "Log in" },
                {2, "Register" },
                {3, "Exit" }
            };
        }

        public void Login()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = GetConsoleSecurePassword();
            _token = _authManager.Login(new User { Name = username, Password = password });
            if (_token == null)
            {
                Console.WriteLine("Cannot log in username and/or password may be incorrect");
            }
            else
            {
                Console.WriteLine("Login successful, user ID {0}", _token.Value.UserId);
            }
        }

        public void Logout()
        {
            _token = null;
            Console.WriteLine();
        }

        public void Register()
        {
            Console.Write("Username for the new user: ");
            string username = Console.ReadLine();
            Console.Write("Password for the new user: ");
            string password1 = GetConsoleSecurePassword();
            Console.Write("Repeat password: ");
            string password2 = GetConsoleSecurePassword();
            if (password1 != password2)
            {
                Console.WriteLine("Passwords do not match");
                return;
            }
            bool result = _accountManager.Register(new User { Name = username, Password = password1 });
            Console.WriteLine(result ? "Registration successful" : "Unable to register user, may be already present");
        }

        public void Exit()
        {
            _shouldExit = true;
        }

        public void ShowStatsByType()
        {
            Console.Write("Enter '0' or 'Water' to select water counters, or '1' or 'Electricity' to select electricity ones");
            try
            {
                string tp = Console.ReadLine();
                CounterType type = (CounterType)Enum.Parse(typeof(CounterType), tp);
                Metric[] res = _metricsManager.FindByType(_authManager.GetLoggedInUserId(_token.Value.Guid), type);
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
                string sd = Console.ReadLine();
                DateTime start = DateTime.Parse(sd);
                Console.Write("Enter end date : ");
                string ed = Console.ReadLine();
                DateTime end = DateTime.Parse(ed);
                Metric[] res = _metricsManager.FindByDate(start, end);
                ShowMetrics(res);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error occured: {0}.", exception.Message);
            }
        }

        public void ShowAllStats()
        {

        }

        #region Helper Methods

        private static string GetConsoleSecurePassword()
        {
            StringBuilder pwd = new StringBuilder();
            while (true)
            {
                ConsoleKeyInfo i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (i.Key == ConsoleKey.Backspace)
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
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
        }

        private void ShowMetrics(Metric[] metrics)
        {
            Console.WriteLine("METRIC DATA: ");
            if (metrics.Length == 0) Console.WriteLine("No data to display.");
            foreach (var metric in metrics)
            {
                Console.WriteLine("Counter: {0} Date: {1} Value: {2}", metric.CounterId, metric.MetricDate, metric.MetricValue);
            }
        }

        private bool CheckForAdmin() => _token.HasValue && _authManager.GetLoggedInUserId(_token.Value.Guid) == 1;

        #endregion
    }
}