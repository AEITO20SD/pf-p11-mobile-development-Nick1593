using System;
using System.Collections.Generic;
using System.Text;

namespace Tamagotchi.Models
{
    public class Pet
    {
        private int _health = 100;
        private int _minHealth = 0;
        private int _maxHealth = 100;

        private int _attention = 100;
        private int _minAttention = 0;
        private int _maxAttention = 150;

        private int _nutrition;
        private int _minNutrition = 0;
        private int _maxNutrition = 150;

        private int _sleep;
        private int _minSleep = 0;
        private int _maxSleep = 100;

        public Pet()
        {
            Health = _health;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; } = health;
        public int Attention { get; set; } = 150;
        public int Nutrition { get; set; } = 150;
        public int Sleep { get; set; } = 100;
        public DateTime Birth { get; set; }
        public DateTime Death { get; set; }

    }
}
