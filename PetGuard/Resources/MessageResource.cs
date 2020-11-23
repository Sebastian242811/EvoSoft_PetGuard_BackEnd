using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Resources
{
    public class MessageResource
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public byte File { get; set; }
        public int TransmitterId { get; set; }
        public int ReciberId { get; set; }
        public int ChatId { get; set; }
    }
}
