using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Application.Contract.Products
{
    public class ProductDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime ProductDate { get; set; }
        public string ManufacturePhone { get; set; }
        public string ManufactureEmail { get; set; }
        public bool IsAvailable { get; set; }
    }
}
