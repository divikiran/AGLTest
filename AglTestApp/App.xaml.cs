using System;
using AglTestApp.Views;
using Microsoft.Practices.Unity;
using Xamarin.Forms;
using AglTestApp.Interfaces;
using AglTestApp.Implementations;

namespace AglTestApp
{
    public partial class App : Application
    {

        public static UnityContainer Container
        {
            get;
            set;
        }

        public App()
        {
            InitializeComponent();

            if (Container == null)
            {
                Container = new UnityContainer();
            }

            Initialize();

            MainPage = new NavigationPage(Container.Resolve<PetsPage>());
        }

        private void Initialize()
        {
            //Container.RegisterType<IRepository<T>, Repository>();
            Container.RegisterType<IOwnersRepository, OwnersRepository>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
