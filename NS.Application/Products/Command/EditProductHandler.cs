using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NS.Infrastructure.EfCore;

namespace NS.Application.Products.Command
{
    public class EditProductHandler:IRequestHandler<EditProductCommand>
    {
        private readonly ProductDbContext _context;
        private readonly IHttpContextAccessor _http;

        public EditProductHandler(ProductDbContext context, IHttpContextAccessor http)
        {
            _context = context;
            _http = http;
        }

        public async Task<Unit> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var userId = _http.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.Id);

            if (product == null)
                throw new Exception("محصول پیدا نشد");

            if (product.CreatedBy != userId)
                throw new Exception("شما اجازه ویرایش این محصول را ندارید");

            product.Edit(request.Name, request.ProductDate, request.ManufacturePhone, request.ManufactureEmail, request.IsAvailable);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
