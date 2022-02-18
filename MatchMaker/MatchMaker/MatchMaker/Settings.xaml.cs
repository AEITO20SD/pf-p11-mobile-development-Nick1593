using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace MatchMaker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            InitializeComponent();
            if (Preferences.Get("math_type", false))
            {
                Switcher.IsToggled = true;
            }
        }
        void SwitchToggled(object sender, ToggledEventArgs e)
        {
            if(e.Value == true)
            {
                Preferences.Set("math_type", true);
            }
            else
            {
                Preferences.Set("math_type", false);
            }
        }
    }
}