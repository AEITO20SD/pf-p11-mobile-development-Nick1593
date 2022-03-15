using System;
using System.Collections.Generic;
using System.Text;

namespace Tamagotchi.Models
{
    internal class Tamagotchi
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attention { get; set; }
        public int Nutrition { get; set; }
        public int Sleep { get; set; }
        public DateTime Birth { get; set; }
        public DateTime Death { get; set; }

    }
}
