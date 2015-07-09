using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using LinqToTwitter;
using TwitterJam.Implementation;
using TwitterJam.Interfaces;

namespace TwitterJam
{
    internal class Program
    {

        private static void Main(string[] args)
        {

            IContainer container = new IoC().GetContainer();

            ITwitterService service = container.Resolve<ITwitterService>();

            service.Authorise("evRKMja4psyaHoevCVMPlCbHm", "W72GjBqSZ5fQ6uVDMkMYpoDKfiqwAaOyLNMczZJKdKX3yk35Ev",
                "3366075040-AtwlMptYENBFVmdDtU8A08EuyoNuMRFAQmZTzzq","ouBcNL2hawU7JUQPjrWJ1Ehai7sh3HiUUycLrXl2E2YB0");

            ITwitterStatusFeed timeline = service.FetchTimeLine();
        }
    }
}