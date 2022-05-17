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
        private PetType _petType;
        private bool _hasBeenSet;
        public ICommand SelectTypeCommand => new Command(async () => await SelectType());
        public AddPetViewModel(TamagotchiService service)
        {
            _services = service;
            _hasBeenSet = false;
        }
        public IList<PetType> PetTypes
        {
            get
            {
                return _services.GetPetTypesList();
            }
        }
        public PetType PetType
        {
            get
            {
                return _petType;
            }
            set
            {
                _petType = value;
                NotifyPropertyChanged("PetType");

                if(value != null)
                {
                    _hasBeenSet = true;
                    NotifyPropertyChanged("HasBeenSet");
                }
            }
        }
        public bool HasBeenSet
        {
            get 
            { 
                return _hasBeenSet;
            }
        }
        public async Task SelectType()
        {
            await _services.SavePet(PetType);
            await App.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
