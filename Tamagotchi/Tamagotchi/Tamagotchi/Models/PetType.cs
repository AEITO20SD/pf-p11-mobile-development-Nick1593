using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tamagotchi.Models
{
    public class PetType
    {
        // different pet types connected with one to many relation to pets & imagetype
        public PetType()
        {
            Pets = new HashSet<Pet>();
            ImageTypes = new HashSet<ImageType>();
        }
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string TypeName { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
        public virtual ICollection<ImageType> ImageTypes { get; set; }
    }
}
