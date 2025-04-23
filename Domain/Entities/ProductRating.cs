using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
    public class ProductRating : BaseEntity<long>
    {
        public Guid UserId { get; set; }

        public long ProductId { get; set; }

        public int Stars { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }


    }
}
