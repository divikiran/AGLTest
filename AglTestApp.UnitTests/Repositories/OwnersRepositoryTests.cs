using NUnit.Framework;
using System;
using AglTestApp.Interfaces;
using Microsoft.Practices.Unity;

namespace AglTestApp.UnitTests.Repositories
{
    [TestFixture()]
    public class OwnersRepositoryTests : BaseTests
    {
        public IOwnersRepository OwnersRepo { get; private set; }

        public override void Setup()
        {
            base.Setup();
            OwnersRepo = Container.Resolve<IOwnersRepository>();
        }

		[Test()]
		public async void Should_Be_Data_Collection_Of_Six()
		{
            var ownerPetsList = await OwnersRepo.GetData();
			Assert.IsTrue(ownerPetsList.Count == 6);
		}
    }
}
