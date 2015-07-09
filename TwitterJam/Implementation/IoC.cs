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

            containerBuilder.RegisterType<ITwitterUser>().As<LttUser>();

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
