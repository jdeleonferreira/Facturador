using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class Item
    {

        int id;
        public string? name { get; set; }
        public string? description { get; set; } = null;

        public decimal price { get; set; }

        public int? quantity { get; set; }


    }
}
