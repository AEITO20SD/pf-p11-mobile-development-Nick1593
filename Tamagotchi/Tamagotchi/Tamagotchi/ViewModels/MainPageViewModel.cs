using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Tamagotchi.Services;
using Tamagotchi.Models;
using Tamagotchi.View;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;
using System.Windows.Input;

namespace Tamagotchi.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly TamagotchiService _service;
        public ICommand AddNewPetCommand => new Command(GoToAddPet);

        public MainPageViewModel(TamagotchiService service)
        {
            _service = service;
        }
        public async void CheckTamagotchi()
        {
            var pets = await _service.GetPetListAsync();
            var petsLast = await _service.GetPetLastOrDefault();

            if (pets == null)
            {
                GoToAddPet();
            }
            else if (petsLast.Death != null)
            {
                GoToAddPet();
            }
        }
        public async void GoToAddPet()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new AddPet());
        }
    }
}
