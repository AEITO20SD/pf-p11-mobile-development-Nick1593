using System.Collections.Generic;
using System.Threading.Tasks;
using Tamagotchi.Models;

namespace Tamagotchi.Interfaces
{
    public interface IPetTypeService
    {
        public IList<PetType> GetPetTypesList();
    }
}
