using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Tamagotchi.Services
{
    // Property changed to bring changes in variables to the screen
    public class OnPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}