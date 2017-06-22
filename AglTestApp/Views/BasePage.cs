using System;
using AglTestApp.ViewModels;
using Xamarin.Forms;

namespace AglTestApp.Views
{
    public class BasePage : ContentPage
    {
        public BasePage()
        {
            //InitializeComponent();
        }
        public BaseViewModel BaseViewModel
		{
			get;
			set;
		}

		protected async override void OnDisappearing()
		{
			base.OnDisappearing();
			if (BindingContext != null && BindingContext is BaseViewModel)
			{
                BaseViewModel = (BaseViewModel)BindingContext;
				BaseViewModel.CurrentPage = this;
				BaseViewModel.Navigation = this.Navigation;
				await BaseViewModel?.OnDisappearing();
			}
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();

			if (BindingContext != null && BindingContext is BaseViewModel)
			{
				BaseViewModel = (BaseViewModel)BindingContext;
				BaseViewModel.CurrentPage = this;
				BaseViewModel.Navigation = this.Navigation;
				await BaseViewModel?.OnAppearing();
			}
		}
    }
}
