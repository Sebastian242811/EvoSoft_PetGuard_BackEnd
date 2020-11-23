using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Resources.Saves
{
    public class SaveClientResource
    {
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public Byte[] Picture { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public char Gender { get; set; }
    }
}
