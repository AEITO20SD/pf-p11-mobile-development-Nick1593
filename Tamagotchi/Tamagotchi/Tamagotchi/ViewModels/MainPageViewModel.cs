using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows.Input;
using Tamagotchi.Services;
using Tamagotchi.Models;
using Tamagotchi.View;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Tamagotchi.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly TamagotchiService _service;
        public ICommand AddNewPetCommand => new Command(async () => await GoToAddPet());
        public MainPageViewModel(TamagotchiService service)
        {
            _service = service;
        }
        public async Task CheckTamagotchi()
        {
            var pets = await _service.GetPetListAsync();
            var petsLast = pets.LastOrDefault();

            if (pets.Count == 0)
            {
                await GoToAddPet();
            }
            else if (petsLast.Death != null)
            {
                await GoToAddPet();
            }
        }
        public async Task GoToAddPet()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new AddPet(_service));
        }
    }
}
