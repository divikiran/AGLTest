using NUnit.Framework;
using System;
using Microsoft.Practices.Unity;
using Acr.UserDialogs;
using AglTestApp.Interfaces;
using AglTestApp.UnitTests.MockImplementation;

namespace AglTestApp.UnitTests
{
    [TestFixture()]
    public class BaseTests
    {
		public UnityContainer Container
		{
			get;
			set;
		}

		[SetUp]
        public virtual void Setup()
		{
			Container = new UnityContainer();
			Container.RegisterType<IOwnersRepository, OwnersMockRepository>();
		}
    }
}
