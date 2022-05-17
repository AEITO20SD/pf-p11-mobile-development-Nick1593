using System;
using System.Collections.Generic;
using System.Linq;
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
        public IList<PetType> GetPetTypesList()
        {
            var x = _context.PetTypes.ToList();

            return x;
        }
        public async Task SavePet(PetType petType)
        {
            Console.WriteLine(petType.TypeName);
            try
            {
                var pet = new Pet();
                pet.PetType = petType;
                pet.PetName = petType.TypeName;
                await _context.AddAsync<Pet>(pet);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
            }
        }
        public async Task UpdatePet(Pet pet)
        {
            _context.Pets.Update(pet);
            await _context.SaveChangesAsync();
        }
    }
}
