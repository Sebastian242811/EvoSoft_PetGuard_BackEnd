using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Resources
{
    public class ServiceResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public ClientResource Client { get; set; }
        public PetKeeperResource PetKeeper { get; set; }
    }
}
