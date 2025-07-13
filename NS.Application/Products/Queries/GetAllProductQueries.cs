using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NS.Application.Contract.Products;

namespace NS.Application.Products.Queries
{
    public class GetAllProductQueries:IRequest<List<ProductDto>>
    {

    }
}
