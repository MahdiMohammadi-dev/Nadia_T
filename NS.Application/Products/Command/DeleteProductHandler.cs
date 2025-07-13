using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NS.Infrastructure.EfCore;

namespace NS.Application.Products.Command
{
    public class DeleteProductHandler:IRequestHandler<DeleteProductCommand>
    {
        private readonly ProductDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DeleteProductHandler(ProductDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.Id);
            if (product == null) throw new Exception("محصول پیدا نشد");
            if (product.CreatedBy != userId)
            {
                throw new Exception("شما اجازه حذف را ندارید");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
