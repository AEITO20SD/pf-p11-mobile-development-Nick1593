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
        // database name
        private readonly string _databasename = "tamagotchi.db";
        // "tags" of images
        private readonly List<string> _tags = new List<string> { "Happy", "Neutral", "Sad", "Sleep", "Dead", "Egg_Fase_1", "Egg_Fase_2", "Egg_Fase_3", "Egg_Fase_4" };
        // DbSet
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetType> PetTypes { get; set; }
        public DbSet<ImageType> ImageTypes { get; set; }
        // ctor
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
        // Seeding
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Pettypes
            List<PetType> PetTypeList = new List<PetType>();

            PetTypeList.Add(new PetType { Id = 1, TypeName = "Basic" });

            modelBuilder.Entity<PetType>().HasData(
                PetTypeList
            );

            // Basic images
            List<ImageType> ImageTypeList_Basic = new List<ImageType>();

            ImageTypeList_Basic.Add(new ImageType { Id = 1, PetTypeId = PetTypeList[0].Id, Tag = _tags[0], URL = "Tamagotchi.images.pets.basic.tamagotchi_happy.png" });
            ImageTypeList_Basic.Add(new ImageType { Id = 2, PetTypeId = PetTypeList[0].Id, Tag = _tags[1], URL = "Tamagotchi.images.pets.basic.tamagotchi_normal.png" });
            ImageTypeList_Basic.Add(new ImageType { Id = 3, PetTypeId = PetTypeList[0].Id, Tag = _tags[2], URL = "Tamagotchi.images.pets.basic.tamagotchi_sad.png" });
            ImageTypeList_Basic.Add(new ImageType { Id = 4, PetTypeId = PetTypeList[0].Id, Tag = _tags[3], URL = "Tamagotchi.images.pets.basic.tamagotchi_sleep.png" });
            ImageTypeList_Basic.Add(new ImageType { Id = 5, PetTypeId = PetTypeList[0].Id, Tag = _tags[4], URL = "Tamagotchi.images.pets.basic.tamagotchi_dead.png" });
            ImageTypeList_Basic.Add(new ImageType { Id = 6, PetTypeId = PetTypeList[0].Id, Tag = _tags[5], URL = "Tamagotchi.images.eggs.egg_fase_1.png" });
            ImageTypeList_Basic.Add(new ImageType { Id = 7, PetTypeId = PetTypeList[0].Id, Tag = _tags[6], URL = "Tamagotchi.images.eggs.egg_fase_2.png" });
            ImageTypeList_Basic.Add(new ImageType { Id = 8, PetTypeId = PetTypeList[0].Id, Tag = _tags[7], URL = "Tamagotchi.images.eggs.egg_fase_3.png" });
            ImageTypeList_Basic.Add(new ImageType { Id = 9, PetTypeId = PetTypeList[0].Id, Tag = _tags[8], URL = "Tamagotchi.images.eggs.egg_fase_4.png" });

            modelBuilder.Entity<ImageType>().HasData(
                ImageTypeList_Basic
            );
        }
    }
}
