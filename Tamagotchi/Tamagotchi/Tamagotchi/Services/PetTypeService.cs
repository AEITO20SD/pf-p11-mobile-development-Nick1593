using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<List<PetType>> GetPetTypesListAsync()
        {
            var x = await _context.PetTypes.ToListAsync();

            return x;
        }
    }
}
