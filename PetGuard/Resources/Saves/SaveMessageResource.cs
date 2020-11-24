using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Resources.Saves
{
    public class SaveMessageResource
    {
        public string Text { get; set; }
        public byte File { get; set; }
        public int TransmitterId { get; set; }
        public int ReciberId { get; set; }
        public int ChatId { get; set; }
    }
}
