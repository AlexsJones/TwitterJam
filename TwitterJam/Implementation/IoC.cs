using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using TwitterJam.Interfaces;

namespace TwitterJam.Implementation
{
    public class IoC
    {
        public delegate void RegisterThirdPartyDependencies(ContainerBuilder c);

        public RegisterThirdPartyDependencies RegistrationDelegate = null;

        ContainerBuilder GetContainerBuilder()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<LttPlace>().As<ITwitterPlace>();

            containerBuilder.RegisterType<LttUser>().As<ITwitterUser>();

            containerBuilder.RegisterType<LttStatusInformation>().As<ITwitterStatusInformation>();

            containerBuilder.RegisterType<LttStatusFeed>().As<ITwitterStatusFeed>();

            containerBuilder.RegisterType<LttService>().As<ITwitterService>();

            return containerBuilder;
        }

        public IContainer GetContainer()
        {
            var container = GetContainerBuilder();

            if (RegistrationDelegate != null)
                RegistrationDelegate(container);

            return container.Build();
        }
    }
}
