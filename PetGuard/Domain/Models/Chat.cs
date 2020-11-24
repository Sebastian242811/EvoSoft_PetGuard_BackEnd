﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuard.Domain.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Message> Messages { get; set; } = new List<Message>();
    }
}
