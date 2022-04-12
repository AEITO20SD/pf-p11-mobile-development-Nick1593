using System;
using Xamarin.Forms;
using Microsoft.EntityFrameworkCore;
using Tamagotchi.Services;
using Tamagotchi.Interfaces;
using Tamagotchi.ViewModels;
using Nancy.TinyIoc;

namespace Tamagotchi
{
    public partial class App : Application
    {
        public readonly TinyIoCContainer _container;
        public App()
        {
            InitializeComponent();

            _container = new TinyIoCContainer();

            _container.Register<TamagotchiContext>();
            _container.Register<ITamagotchiService, TamagotchiService>();

            MainPage = new NavigationPage(new MainPage(_container.Resolve<TamagotchiService>()));

            var db = new TamagotchiContext();

            db.Database.Migrate();
        }

        protected async override void OnStart()
        {
            var vm = new MainPageViewModel(_container.Resolve<TamagotchiService>());

            //var vm = (MainPageViewModel)MainPage.BindingContext;

            await vm.CheckTamagotchi();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
