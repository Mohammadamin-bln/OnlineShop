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
    public class ProductOffer : BaseEntity<long>
    {
        public long ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        public long OfferId { get; set; }
        [ForeignKey(nameof(OfferId))]
        public Offer Offer { get; set; }
    }
}
