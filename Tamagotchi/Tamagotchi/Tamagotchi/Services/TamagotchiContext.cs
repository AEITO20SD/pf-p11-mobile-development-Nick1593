using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Xamarin.Essentials;
using Tamagotchi.Models;

namespace Tamagotchi.Services
{
    public class TamagotchiContext : DbContext
    {
        private readonly string _databasename = "tamagotchi.db";
        private readonly List<string> _tags = new List<string> { "Happy", "Neutral", "Sad", "Sleep", "Dead", "Egg_Fase_1", "Egg_Fase_2", "Egg_Fase_3", "Egg_Fase_4" };
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetType> PetTypes { get; set; }
        public DbSet<ImageType> ImageTypes { get; set; }

        public TamagotchiContext()
        {
            // Needed for IOS
            /*SQLitePCL.Batteries_V2.Init();*/

            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbpath = Path.Combine(FileSystem.AppDataDirectory, _databasename);

            optionsBuilder.UseSqlite($"Filename={dbpath}");
        }
    }
}
