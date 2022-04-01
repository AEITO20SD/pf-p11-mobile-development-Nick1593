using System.Collections.Generic;
using System.Threading.Tasks;
using Tamagotchi.Models;

namespace Tamagotchi.Interfaces
{
    public interface IPetTypeService
    {
        public Task<List<PetType>> GetPetTypesListAsync();
    }
}
