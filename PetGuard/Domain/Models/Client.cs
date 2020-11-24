using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Domain.Models
{
    public class Client : User
    {
        //Add relations

        public List<Service> Services { get; set; }
        public IList<Payment> Payments { get; set; } = new List<Payment>();
        public IList<Pet> Pets { get; set; } = new List<Pet>();
    }
}
