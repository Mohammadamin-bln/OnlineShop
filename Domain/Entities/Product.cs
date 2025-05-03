using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Domain.Entities
{
    public class Product : BaseEntity<long>
    {

        public long ColorId { get; set; }
        public long BrandId { get; set; }
        public long CategoryId { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public SizeOfProduct Size { get; set; }

        [ForeignKey(nameof(ColorId))]
        public virtual ProductColor ProductColor { get; set; }

        [ForeignKey(nameof(BrandId))]
        public virtual Brand Brand { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }

        public string Description { get; set; }

        public int Stock { get; set; }


        public ICollection<ProductRating> ProductRatings { get; set; }
        public ICollection<ProductOffer> ProductOffers { get; set; }
        public string Photo { get; set; }







    }
}
