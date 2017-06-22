using NUnit.Framework;
using System;
using AglTestApp.Interfaces;
using AglTestApp.Views;
using AglTestApp.Implementations;
using Microsoft.Practices.Unity;

namespace AglTestApp.UnitTests
{
    [TestFixture()]
    public class Test
    {
        public IOwnersRepository OwnersRepo
        {
            get;
            set;
        }

        [SetUp]
        public void Setup()
        {
            OwnersRepo = App.Container.Resolve<IOwnersRepository>();
        }

        [Test()]
        public void TestCase()
        {
           // OwnersRepo.
        }
    }
}
