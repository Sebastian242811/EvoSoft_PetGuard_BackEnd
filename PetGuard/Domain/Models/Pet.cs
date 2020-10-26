using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Domain.Models
{
    public class Pet
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public EBreed Breed { get; set; }
    }
}
