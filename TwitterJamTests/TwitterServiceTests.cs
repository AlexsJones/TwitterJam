﻿using System;
using Autofac;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using TwitterJam.Implementation;
using TwitterJam.Interfaces;
using NSubstitute;
using System.Linq;
using TwitterJamTests.Mocks;
using LinqToTwitter;

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

                c.RegisterType<LttAuthorizer>().As<ITwitterAuthorizer>();

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
        public void TestResolutionSuccess()
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

        [Test]
        public void TestStatusInformation()
        {
            var si = Substitute.For<ITwitterStatusInformation>();

            si.Place = Substitute.For<ITwitterPlace>();

            si.Place.Country.Returns("United Kingdom");

            si.Place.Country.Should().Be("United Kingdom");

        }

        [Test]
        public void TestStatusFeedMock()
        {
            var statusFeed = _container.Resolve<ITwitterStatusFeed>();

            var mockedItem = Substitute.For<ITwitterStatusInformation>();

            mockedItem.ScreenName.Returns("MockedItem");

            statusFeed.AddItem(mockedItem);

            statusFeed.StatusInformation.Count.Should().Be(1);

            statusFeed.StatusInformation.First().ScreenName.Should().Be("MockedItem");
        }

        [Test]
        public void TestAuthNotInitialized()
        {
            var service = _container.Resolve<ITwitterService>();

            Action c = () => { service.FetchTimeLine(); };

            c.ShouldThrow<Exception>();
        }

        [Test]
        public void TestAuthInitialized()
        {
            var ioc = new IoC();

            ioc.RegistrationDelegate += (c) =>
            {
                c.RegisterType<LttPlace>().As<ITwitterPlace>();

                c.RegisterType<LttUser>().As<ITwitterUser>();

                c.RegisterType<LttStatusInformation>().As<ITwitterStatusInformation>();

                c.RegisterType<MockAuthorzier>().As<ITwitterAuthorizer>();

                c.RegisterType<LttStatusFeed>().As<ITwitterStatusFeed>();

                c.RegisterType<LttService>().As<ITwitterService>();

            };

            _container = ioc.GetContainer();

            Action d = () => { _container.Resolve<ITwitterService>().FetchTimeLine(); };

            d.ShouldThrow<Exception>();
        }

        [Test]
        public void TestMockedService()
        {
            var ioc = new IoC();


            var mockedAuthorizer = Substitute.For<ITwitterAuthorizer>();

            mockedAuthorizer.Authorize(
                Arg.Any<string>(),
                Arg.Any<string>(),
               Arg.Any<string>(),
               Arg.Any<string>()).ReturnsForAnyArgs(true);

            var mockedTwitterContext = Substitute.For<LttContext>(
                Substitute.For<IAuthorizer>()
                );

            mockedAuthorizer.FetchContext().ReturnsForAnyArgs(mockedTwitterContext);

            ioc.RegistrationDelegate += (c) =>
            {
                c.RegisterType<LttPlace>().As<ITwitterPlace>();

                c.RegisterType<LttUser>().As<ITwitterUser>();

                c.RegisterType<LttStatusInformation>().As<ITwitterStatusInformation>();

                c.Register(d => mockedAuthorizer.As<ITwitterAuthorizer>());

                c.RegisterType<LttStatusFeed>().As<ITwitterStatusFeed>();

                c.RegisterType<LttService>().As<ITwitterService>();

            };

            _container = ioc.GetContainer();

            var service = _container.Resolve<ITwitterService>();

            service.Authorise("Foo", "Bar", "A", "B").Should().BeTrue();

            Action f = () => { service.FetchTimeLine(); };

            f.ShouldThrow<Exception>();
        }
    }
}
