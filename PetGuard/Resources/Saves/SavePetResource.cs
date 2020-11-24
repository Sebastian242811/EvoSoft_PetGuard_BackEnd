<<<<<<< HEAD
﻿using System;
=======
﻿using PetGuard.Domain.Models;
using System;
>>>>>>> development4
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Resources.Saves
{
    public class SavePetResource
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int ClientId { get; set; }
        [Required]
        public EBreed Breed { get; set; }
    }
}
