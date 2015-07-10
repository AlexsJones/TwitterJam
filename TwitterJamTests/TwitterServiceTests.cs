using System;
using Autofac;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using TwitterJam.Implementation;
using TwitterJam.Interfaces;

namespace TwitterJamTests
{
    [TestFixture]
    public class TwitterServiceTests
    {
        private IContainer _container;

        [TestFixtureSetUp]
        public void TestSetup()
        {
            var ioc = new IoC();

            ioc.RegistrationDelegate += (c) =>
            {
                c.RegisterType<LttPlace>().As<ITwitterPlace>();

                c.RegisterType<LttUser>().As<ITwitterUser>();

                c.RegisterType<LttStatusInformation>().As<ITwitterStatusInformation>();

                c.RegisterType<LttStatusFeed>().As<ITwitterStatusFeed>();

                c.RegisterType<LttService>().As<ITwitterService>();

            };
   
            _container = ioc.GetContainer();
        }

        [TestFixtureTearDown]
        public void TestTearDown()
        {
            _container.Dispose();
        }

        [Test]
        public void TestContainer()
        {
            _container.Resolve<ITwitterService>().Should().NotBeNull();

            _container.Resolve<ITwitterService>().Should().BeOfType<LttService>();
        }

        [Test]
        public void TestResolutionFailure()
        {
            Action a = () => _container.Resolve<IDisposable>();

            a.ShouldThrow<Autofac.Core.Registration.ComponentNotRegisteredException>();

        }
    }
}
