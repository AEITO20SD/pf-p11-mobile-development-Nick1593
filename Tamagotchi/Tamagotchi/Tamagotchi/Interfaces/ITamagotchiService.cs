using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi.Models;

namespace Tamagotchi.Interfaces
{
    public interface ITamagotchiService
    {
        public Task<List<Pet>> GetPetListAsync();
        public Task<Pet> GetPetLastOrDefault();
    }
}
