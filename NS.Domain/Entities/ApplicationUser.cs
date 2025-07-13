using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace NS.Domain.Entities
{
    public class ApplicationUser: IdentityUser

    {
        public ICollection<Product> Products { get; set; }
    }
}
