using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Acr.UserDialogs;
using AglTestApp.Views;
using Xamarin.Forms;

namespace AglTestApp.ViewModels
{
    public class BaseViewModel: INotifyPropertyChanged
    {
        public BaseViewModel()
        {
            AcrInstance = UserDialogs.Instance;
        }

        public event PropertyChangedEventHandler PropertyChanged;

		protected void RaisePropertyChanged([CallerMemberName] string propertyName = "") =>
		   PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

		

		public INavigation Navigation { get; set; }
		public BasePage CurrentPage { get; internal set; }

        public IUserDialogs AcrInstance
        {
            get;
            set;
        }

        string _title = "";
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                RaisePropertyChanged();
            }
        }

        public async virtual Task OnAppearing() { await Task.FromResult(default(object)); }
		public async virtual Task OnDisappearing() { await Task.FromResult(default(object)); }
    }
}
