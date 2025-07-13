
using MediatR;

namespace NS.Application.Products.Command
{
    public class CreateProductCommand:IRequest
    {

        public string Name { get; set; }
        public DateTime ProductDate { get; set; }
        public string ManufacturePhone { get; set; }
        public string ManufactureEmail { get; set; }
        public bool IsAvailable { get; set; }

    }
}
