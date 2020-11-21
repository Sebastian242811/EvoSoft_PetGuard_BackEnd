using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Resources
{
    public class PaymentResource
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int CardId { get; set; }
        public string PaymentDetail { get; set; }
        public DateTime Date { get; set; }
        public int TotalAmmount { get; set; }
    }
}
