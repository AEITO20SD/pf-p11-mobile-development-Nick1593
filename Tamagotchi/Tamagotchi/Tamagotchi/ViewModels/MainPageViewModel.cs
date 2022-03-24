using System;
using System.Collections.Generic;
using System.Text;
using Tamagotchi.Services;
using Tamagotchi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Tamagotchi.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {


        private readonly TamagotchiContext _context;
        public MainPageViewModel(TamagotchiContext context)
        {
            _context = context;
        }
        public void CheckTamagotchi()
        {
            var pets = _context.Pets.ToListAsync();
            var petsLast = _context.Pets.LastOrDefault();

            if (pets == null)
            {

            }
            else if (petsLast.Death != null)
            {

            }
        }
    }
}
