using System;
using Xamarin.Forms;
using Microsoft.EntityFrameworkCore;
using Tamagotchi.Services;
using Tamagotchi.ViewModels;

namespace Tamagotchi
{
    public partial class App : Application
    {
        public readonly TamagotchiContext _context;
        public App(TamagotchiContext context)
        {
            InitializeComponent();

            MainPage = new MainPage();

            var db = new TamagotchiContext();

            db.Database.Migrate();

            _context = context;
        }

        protected override void OnStart()
        {
            var vm = new MainPageViewModel(_context);

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
