using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AulaAPI.Models
{
    public class Cliente
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }
    }
}
