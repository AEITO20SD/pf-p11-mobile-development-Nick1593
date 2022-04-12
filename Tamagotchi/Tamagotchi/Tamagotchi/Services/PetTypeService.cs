using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Tamagotchi.Models;
using Tamagotchi.Interfaces;

namespace Tamagotchi.Services
{
    public class PetTypeService : IPetTypeService
    {
        private readonly TamagotchiContext _context;
        public PetTypeService(TamagotchiContext context)
        {
            _context = context;
        }
        public IList<PetType> GetPetTypesList()
        {
            var x = _context.PetTypes.Include(p => p.ImageTypes).ToList();

            return x;
        }
    }
}
