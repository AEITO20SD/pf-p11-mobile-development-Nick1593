using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Tamagotchi.Services
{
    public abstract class BaseViewModel : OnPropertyChanged
    {
        public Dictionary<string, ICommand> Commands { get; protected set; }
        public BaseViewModel()
        {
            Commands = new Dictionary<string, ICommand>();
        }
    }
}
