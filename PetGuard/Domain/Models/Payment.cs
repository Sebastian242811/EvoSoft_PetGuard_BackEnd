using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Domain.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
        public string PaymentDetail { get; set; }
        public DateTime Date { get; set; }
        public int TotalAmmount { get; set; }

        public Payment()
        {
            this.Date = DateTime.UtcNow;
        }
    }
}
