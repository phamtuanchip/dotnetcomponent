﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst
{
    public class Manager : Person
    {
        [Key]
        public string ManagerCode { get; set; }
        [ConcurrencyCheck]
        [MinLength(5)]
        [MaxLength(20,ErrorMessage="Le nom ne peut pas avoir plus de 20 caractères")]
        public new string Name { get; set; }
        public virtual ICollection<Collaborator> Collaborators { get; set; }
    }
}
