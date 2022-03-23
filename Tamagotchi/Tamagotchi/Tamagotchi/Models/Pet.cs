using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tamagotchi.Models
{
    public class Pet
    {
        private readonly static int _health = 100;
        private readonly static int _attention = 100;
        private readonly static int _nutrition = 100;
        private readonly static int _sleep = 100;
        private readonly DateTime _birth = DateTime.Now;

        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string PetName { get; set; }
        [Required, Range(0,100)]
        public int Health { get; set; } = _health;
        [Required, Range(0,150)]
        public int Attention { get; set; } = _attention;
        [Required, Range(0,150)]
        public int Nutrition { get; set; } = _nutrition;
        [Required, Range(0,100)]
        public int Sleep { get; set; } = _sleep;
        protected DateTime Birth { get => _birth; }
        protected DateTime Death { get; set; }
        public int PetTypeId { get; set; }
        public virtual PetType PetType { get; set; }
    }
}
