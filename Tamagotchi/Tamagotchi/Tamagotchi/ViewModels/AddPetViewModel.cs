using Tamagotchi.Services;

namespace Tamagotchi.ViewModels
{
    public class AddPetViewModel : BaseViewModel
    {
        private readonly PetTypeService _services;
        public AddPetViewModel(PetTypeService service)
        {
            _services = service;
        }
    }
}
