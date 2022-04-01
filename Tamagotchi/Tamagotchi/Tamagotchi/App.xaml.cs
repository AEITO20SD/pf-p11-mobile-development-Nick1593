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

            _container.Register<ITamagotchiService, TamagotchiService>();
            _container.Register<TamagotchiContext>();

            MainPage = new MainPage(_container.Resolve<TamagotchiService>());

            var db = new TamagotchiContext();

            db.Database.Migrate();
        }

        protected override void OnStart()
        {
            var vm = new MainPageViewModel(_container.Resolve<TamagotchiService>());

            vm.CheckTamagotchi();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
