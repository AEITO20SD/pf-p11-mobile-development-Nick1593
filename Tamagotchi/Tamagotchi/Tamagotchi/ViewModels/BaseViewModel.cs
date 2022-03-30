using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Tamagotchi.Services;

namespace Tamagotchi.ViewModels
{
    // Baseviewmodel to allow commands to be binded
    public abstract class BaseViewModel : NotifyPropertyChanged
    {
        public Dictionary<string, ICommand> Commands { get; protected set; }
        public BaseViewModel()
        {
            Commands = new Dictionary<string, ICommand>();
        }
    }
}
