using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class BaseEntity<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime DateCreate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
