using System.Collections.Generic;
using System.Threading.Tasks;
using Tamagotchi.Models;

namespace Tamagotchi.Interfaces
{
    public interface ITamagotchiService
    {
        public Task<List<Pet>> GetPetListAsync();
        public IList<PetType> GetPetTypesList();
    }
}
