using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Resources
{
    public class CardResource
    {
        public int Id { get; set; }
        public string CardName { get; set; }
        public int CardNumber { get; set; }
        public DateTime ExpDate { get; set; }
    }
}
