using System.Text;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NS.Application.Products.Command;
using NS.Domain.Entities;
using NS.Infrastructure.EfCore;
namespace NS.Infrastructure.Core
{
    public class Bootstrapper
    {

        public static void Config(IServiceCollection builder, string connectionString)
        {
            builder.AddDbContext<ProductDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.AddHttpContextAccessor();

            builder.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ProductDbContext>()
                .AddDefaultTokenProviders();

            var key = Encoding.UTF8.GetBytes("THIS_IS_SUPER_SECRET_KEY_FOR_JWT_123456");

            builder.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
            {
                option.RequireHttpsMetadata = false;
                option.SaveToken = true;
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });






        }
    }
}
