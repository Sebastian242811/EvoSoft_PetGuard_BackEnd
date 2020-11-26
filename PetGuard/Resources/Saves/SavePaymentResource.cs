using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Resources.Saves
{
    public class SavePaymentResource
    {
        public int ClientId { get; set; }
        public int CardId { get; set; }
        public string PaymentDetail { get; set; }
        public int TotalAmmount { get; set; }
    }
}
