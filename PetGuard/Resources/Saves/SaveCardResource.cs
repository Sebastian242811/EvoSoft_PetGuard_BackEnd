using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Resources.Saves
{
    public class SaveCardResource
    {
        public string CardName { get; set; }
        public int CardNumber { get; set; }
        public DateTime ExpDate { get; set; }
    }
}
