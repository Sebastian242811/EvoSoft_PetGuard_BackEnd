using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Domain.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public byte File { get; set; }
        public int TransmitterId { get; set; }
        public User Transmitter { get; set; }
        public int ReciberId { get; set; }
        public User Reciber { get; set; }
        public int ChatId { get; set; }
        public Chat Chat { get; set; }
    }
}
