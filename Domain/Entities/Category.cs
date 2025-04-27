using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
    public class Category :BaseEntity<long>
    {
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
