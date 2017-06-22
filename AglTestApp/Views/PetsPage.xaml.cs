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
        }

        public PetsPage(PetsViewModel petViewModel)
        {
            BindingContext = ViewModel = petViewModel;
            InitializeComponent();
        }
    }
}
