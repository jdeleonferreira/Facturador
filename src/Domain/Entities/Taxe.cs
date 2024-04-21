using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class Taxe
    {
        public int IdTaxe { get; }
        public string? name { get; set; }

        public float value { get; set; }

        
    }
}
