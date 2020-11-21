using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Resources
{
    public class PetResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public int ClientId { get; set; }
    }
}
