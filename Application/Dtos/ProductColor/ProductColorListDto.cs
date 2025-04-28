using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ProductColor
{
    public record ProductColorListDto
    {
        public string Name { get; set; }

        public string? HexCode { get; set; }
        public long Id { get; set; }
    }
}
