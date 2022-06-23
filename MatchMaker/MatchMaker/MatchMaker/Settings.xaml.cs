using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using MatchMaker.Interfaces;
using MatchMaker.Services;

namespace MatchMaker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        private readonly ISettingsService _settingsService;
        public Settings(ISettingsService settingsService)
        {
            InitializeComponent();
            _settingsService = settingsService;

            if (_settingsService.GetSetting("math_type"))
            {
                Switcher.IsToggled = true;
            }
        }
        void SwitchToggled(object sender, ToggledEventArgs e)
        {
            if(e.Value == true)
            {
                _settingsService.SetSetting("math_type", true);
            }
            else
            {
                _settingsService.SetSetting("math_type", false);
            }
        }
    }
}