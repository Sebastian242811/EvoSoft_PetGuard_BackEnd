using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Resources.Saves
{
    public class SaveServiceResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        [Required]
        [MaxLength(50)]
        public string Location { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public int Duration { get; set; }
    }
}
