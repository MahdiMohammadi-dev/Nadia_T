using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NS.Application.Contract.Products;
using NS.Infrastructure.EfCore;

namespace NS.Application.Products.Queries
{
    public class GetAllProductHandler:IRequestHandler<GetAllProductQueries,List<ProductDto>>
    {
        private readonly ProductDbContext _context;

        public GetAllProductHandler(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDto>> Handle(GetAllProductQueries request, CancellationToken cancellationToken)
        {
            return await _context.Products
                .Select(x => new ProductDto
                {
                    Id = x.Id, Name = x.Name, ProductDate = x.ProductDate,
                    ManufactureEmail = x.ManufactureEmail,
                    ManufacturePhone = x.ManufacturePhone,
                    IsAvailable = x.IsAvailable
                }).ToListAsync();
        }
    }
}
