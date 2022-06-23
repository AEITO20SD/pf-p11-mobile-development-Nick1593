using Xamarin.Essentials;
using MatchMaker.Interfaces;

namespace MatchMaker.Services
{
    public class SettingsService : ISettingsService
    {
        public bool GetSetting(string settingName)
        {
            return Preferences.Get(settingName, false);
        }

        public void SetSetting(string settingName, bool setting)
        {
            Preferences.Set(settingName, setting);
        }
    }
}
