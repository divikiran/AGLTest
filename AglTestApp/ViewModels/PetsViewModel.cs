using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using AglTestApp.Helpers;
using AglTestApp.Implementations;
using AglTestApp.Interfaces;
using AglTestApp.Models;

namespace AglTestApp.ViewModels
{
    public class PetsViewModel : BaseViewModel
    {
        List<OwnerPets> _ownerPetsList;
        public List<OwnerPets> OwnerPetsList
        {
            get
            {
                return _ownerPetsList;
            }

            set
            {
                _ownerPetsList = value;
                RaisePropertyChanged(nameof(OwnerPetsList));
                RaisePropertyChanged(nameof(PetsList));
            }
        }

        public ObservableCollection<ObservableGroupCollection<string, PetsCollection>> PetsList
        {
            get
            {
                if (OwnerPetsList == null)
                    return null;

                var breakDownDataToRequiredFormat = (from b in OwnerPetsList
                                                     group b by new { b.Gender, b.Pets } into groupedByGender
                                                     where groupedByGender.Key.Pets != null
                                                     from pet in groupedByGender.Key.Pets
                                                     where pet.Type == "Cat"
                                                     group pet by new { pet, groupedByGender.Key.Gender } into groupedByPet
                                                     select new PetsCollection(groupedByPet.Key.Gender, groupedByPet.Key.pet)).ToList();

                var formatToGroupedData = breakDownDataToRequiredFormat.OrderBy(e => e.Text)
                                         .GroupBy(e => e.GroupText)
                                         .Select(e => new ObservableGroupCollection<string, PetsCollection>(e))
                                                    .ToList();

                var groupedData = new ObservableCollection<ObservableGroupCollection<string, PetsCollection>>(formatToGroupedData);
                return groupedData;
            }
        }

        public IOwnersRepository OwnerRepo
        {
            get;
            set;
        }

        public PetsViewModel(IOwnersRepository iOwnersRepository)
        {
            OwnerRepo = iOwnersRepository;
            Title = "Pets Collection";
        }

        public async Task GetOwnerPetsList()
        {
            OwnerPetsList = await OwnerRepo.GetData();
        }

        public async override Task OnAppearing()
        {
            await base.OnAppearing();

            if (OwnerPetsList != null)
                return;


            try
            {
#if !APPTESTS
                AcrInstance.ShowLoading();
#endif
                await GetOwnerPetsList();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
#if !APPTESTS
                AcrInstance.HideLoading();
#endif
            }
        }
    }
}
