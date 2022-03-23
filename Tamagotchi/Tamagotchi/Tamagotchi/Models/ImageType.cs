using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tamagotchi.Models
{
    public class ImageType
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Tag { get; set; }
        [Required]
        public string URL { get; set; }
        public int PetTypeId { get; set; }
        public virtual PetType PetType { get; set; }
    }
}
