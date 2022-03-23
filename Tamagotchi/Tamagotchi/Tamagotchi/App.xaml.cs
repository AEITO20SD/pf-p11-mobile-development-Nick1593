using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.EntityFrameworkCore;
using Tamagotchi.Services;

namespace Tamagotchi
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

            var db = new TamagotchiContext();

            db.Database.Migrate();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
