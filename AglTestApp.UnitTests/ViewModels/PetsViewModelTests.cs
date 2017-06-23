using NUnit.Framework;
using Microsoft.Practices.Unity;
using AglTestApp.ViewModels;
using System.Linq;

namespace AglTestApp.UnitTests
{
    [TestFixture()]
    public class PetsViewModelTests : BaseTests
    {
        public PetsViewModel ViewModel
        {
            get;
            private set;
        }

        public override void Setup()
        {
            base.Setup();
			ViewModel = Container.Resolve<PetsViewModel>();
        }

		[Test()]
		public async void Should_Be_Data_Collection_Of_Six()
		{
            await ViewModel.GetOwnerPetsList();
            var ownerPetsList = ViewModel.OwnerPetsList;
            Assert.AreEqual(6, ownerPetsList.Count);
		}

        [Test()]
        public async void Should_Be_Groups_Of_Two_Genders()
        {
			await ViewModel.GetOwnerPetsList();
			var petsList = ViewModel.PetsList;
            Assert.AreEqual(2, petsList.Count);
        }

		[Test()]
		public async void Should_Be_First_Group_Male()
		{
			await ViewModel.GetOwnerPetsList();
			var petsList = ViewModel.PetsList;
            var maleCollection = petsList.FirstOrDefault();
            Assert.AreEqual("Male", maleCollection.Key);
		}

		[Test()]
		public async void Should_Be_Four_Cats_In_Male_Group()
		{
			await ViewModel.GetOwnerPetsList();
            var petsList = ViewModel.PetsList;
			var maleCollection = petsList.FirstOrDefault();
            //Assert.IsTrue(maleCollection.Count == 4);
            Assert.AreEqual(4, maleCollection.Count);
		}

		[Test()]
		public async void Should_Be_First_Alphabetical_Male_Pet_Garfield()
		{
			await ViewModel.GetOwnerPetsList();
			var petsList = ViewModel.PetsList;
			var maleCollection = petsList.FirstOrDefault();
            var firstPet = maleCollection.FirstOrDefault();
            Assert.AreEqual("Garfield", firstPet.Text);
		}

		[Test()]
		public async void Should_Be_Last_Alphabetical_Male_Pet_Tom()
		{
			await ViewModel.GetOwnerPetsList();
			var petsList = ViewModel.PetsList;
			var maleCollection = petsList.FirstOrDefault();
            var lastPet = maleCollection.LastOrDefault();
            Assert.AreEqual("Tom",lastPet.Text);
		}

		[Test()]
		public async void Should_Be_First_Group_Female()
		{
			await ViewModel.GetOwnerPetsList();
			var petsList = ViewModel.PetsList;
            var femaleCollection = petsList.LastOrDefault();
            Assert.AreEqual("Female", femaleCollection.Key);
		}

		[Test()]
		public async void Should_Be_Three_Cats_In_Female_Group()
		{
			await ViewModel.GetOwnerPetsList();
			var petsList = ViewModel.PetsList;
            var maleCollection = petsList.LastOrDefault();
            Assert.AreEqual(3, maleCollection.Count);
		}

		[Test()]
		public async void Should_Be_First_Alphabetical_Female_Pet_Garfield()
		{
			await ViewModel.GetOwnerPetsList();
			var petsList = ViewModel.PetsList;
            var femaleCollection = petsList.LastOrDefault();
			var firstPet = femaleCollection.FirstOrDefault();
            Assert.AreEqual("Garfield", firstPet.Text);
		}

		[Test()]
		public async void Should_Be_Last_Alphabetical_Female_Pet_Tabby()
		{
			await ViewModel.GetOwnerPetsList();
			var petsList = ViewModel.PetsList;
            var femaleCollection = petsList.LastOrDefault();
			var lastPet = femaleCollection.LastOrDefault();
            Assert.AreEqual("Tabby", lastPet.Text);
		}
    }
}
