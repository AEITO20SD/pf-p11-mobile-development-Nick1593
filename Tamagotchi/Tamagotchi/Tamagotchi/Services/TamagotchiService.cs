using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tamagotchi.Interfaces;
using Tamagotchi.Models;

namespace Tamagotchi.Services
{
    public class TamagotchiService : ITamagotchiService
    {
        private readonly TamagotchiContext _context;
        public TamagotchiService(TamagotchiContext context)
        {
            _context = context;
        }
        public async Task<List<Pet>> GetPetListAsync()
        {
            var x = await _context.Pets.ToListAsync();

            return x;
        }
        public async Task<Pet> GetPetLastOrDefault()
        {
            var x = await _context.Pets.LastOrDefaultAsync();
           
            return x;
        }
    }
}
