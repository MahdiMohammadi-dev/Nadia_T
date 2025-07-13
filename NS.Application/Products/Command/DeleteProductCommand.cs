using MediatR;

namespace NS.Application.Products.Command
{
    public class DeleteProductCommand:IRequest
    {
        public long Id { get; set; }

        public DeleteProductCommand(long id)
        {
            Id = id;
        }
    }
}
