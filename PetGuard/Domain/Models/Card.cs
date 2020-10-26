using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Domain.Models
{
    public class Card
    {
        public int CardId { get; set; }
        public string CardName { get; set; }
        public int CardNumber { get; set; }
        public DateTime ExpireDate { get; set; }
        public IList<Payment> Payments { get; set; } = new List<Payment>();
    }
}
