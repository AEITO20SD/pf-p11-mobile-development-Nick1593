using System.Collections.Generic;
using System.Threading.Tasks;
using Tamagotchi.Models;

namespace Tamagotchi.Interfaces
{
    public interface ITamagotchiService
    {
        public Task<List<Pet>> GetPetListAsync();
        public IList<PetType> GetPetTypesList();
        public Task SavePet(PetType petType);
        public Task UpdatePet(Pet pet);
    }
}
