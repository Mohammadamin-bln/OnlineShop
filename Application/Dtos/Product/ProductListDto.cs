using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.Dtos.Product
{
    public record ProductListDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public SizeOfProduct Size { get; set; }  
        public string Photo { get; set; }

        public string ColorName { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }

        public decimal? DiscountedPrice { get; set; }
        public string? DiscountBadge { get; set; }
    }
}
