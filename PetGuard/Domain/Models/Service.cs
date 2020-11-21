using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Domain.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        //Add ServiceType
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int PetKeeperId { get; set; }
        public PetKeeper PetKeeper { get; set; }
    }
}
