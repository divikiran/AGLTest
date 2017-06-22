using System;
using System.Collections.Generic;
using AglTestApp.ViewModels;
using Xamarin.Forms;

namespace AglTestApp.Views
{
    public partial class PetsPage : BasePage
    {
        public PetsViewModel ViewModel
        {
            get;
            set;
        } = new PetsViewModel();

        public PetsPage()
        {
            BindingContext = ViewModel;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();


        }
    }
}
