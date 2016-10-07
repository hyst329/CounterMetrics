using System;

namespace CounterMetrics.Collapsed
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Title = "Collapsed Client";
            var container = Bootstrapper.Init();
        }
    }
}