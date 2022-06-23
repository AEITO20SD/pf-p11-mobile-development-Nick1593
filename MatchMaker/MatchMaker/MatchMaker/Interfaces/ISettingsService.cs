using System;
using System.Collections.Generic;
using System.Text;

namespace MatchMaker.Interfaces
{
    public interface ISettingsService
    {
        public bool GetSetting(string _settingName);
        public void SetSetting(string _settingName, bool _setting);
    }
}
