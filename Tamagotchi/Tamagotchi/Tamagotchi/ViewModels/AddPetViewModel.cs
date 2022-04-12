using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Tamagotchi.Models;
using Tamagotchi.Services;
using Xamarin.Forms;

namespace Tamagotchi.ViewModels
{
    public class AddPetViewModel : BaseViewModel
    {
        private readonly TamagotchiService _services;
        private object _selectedPetType;
        public AddPetViewModel(TamagotchiService service)
        {
            _services = service;
        }
        public IList<PetType> PetTypes
        {
            get
            {
                return _services.GetPetTypesList();
            }
        }
        public object SelectedPetType
        {
            get
            {
                return _selectedPetType;
            }
            set
            {
                _selectedPetType = value;
                NotifyPropertyChanged("SelectedPetType");
            }
        }
    }
}
