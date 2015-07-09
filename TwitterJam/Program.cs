using System;
using Autofac;
using TwitterJam.Implementation;
using TwitterJam.Interfaces;

namespace TwitterJam
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = new IoC().GetContainer();

            var service = container.Resolve<ITwitterService>();

            service.Authorise("evRKMja4psyaHoevCVMPlCbHm", "W72GjBqSZ5fQ6uVDMkMYpoDKfiqwAaOyLNMczZJKdKX3yk35Ev",
                "3366075040-AtwlMptYENBFVmdDtU8A08EuyoNuMRFAQmZTzzq", "ouBcNL2hawU7JUQPjrWJ1Ehai7sh3HiUUycLrXl2E2YB0");

            var timeline = service.FetchTimeLine();

            timeline.StatusInformation.ForEach(
                item => Console.WriteLine(item.Text)
                );

            Console.ReadKey();
        }
    }
}