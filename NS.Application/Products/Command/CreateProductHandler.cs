using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Http;
using NS.Domain.Entities;
using NS.Infrastructure.EfCore;

namespace NS.Application.Products.Command
{
    public class CreateProductHandler:IRequestHandler<CreateProductCommand>
    {
        private readonly ProductDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CreateProductHandler(ProductDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrWhiteSpace(userId))
                throw new Exception("شناسه کاربر یافت نشد!");

            var product = new Product(request.Name, request.ProductDate, request.ManufacturePhone,
                request.ManufactureEmail, request.IsAvailable,userId);

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
