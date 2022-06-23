using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Nancy.TinyIoc;
using MatchMaker.Core;
using MatchMaker.Interfaces;
using MatchMaker.Services;

namespace MatchMaker
{
    public partial class App : Application
    {
        private readonly TinyIoCContainer _container;
        public App()
        {
            InitializeComponent();
            _container = new TinyIoCContainer();
            _container.Register<ISettingsService, SettingsService>();
            _container.Register<IValidation, NameValidation>();
            _container.Register<ICalculator, CalculateASCII>(); 
            _container.Register<ICalculator, CalculateCharacters>();

            MainPage = new NavigationPage (new MainPage(_container.Resolve<CalculateASCII>(), _container.Resolve<CalculateCharacters>(), _container.Resolve<IValidation>(), _container.Resolve<ISettingsService>()));
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
