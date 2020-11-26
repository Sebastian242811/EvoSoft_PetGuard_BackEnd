using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Resources
{
    public class PetKeeperResource
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Lastname { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime Birthday { get; set; }
    }
}
