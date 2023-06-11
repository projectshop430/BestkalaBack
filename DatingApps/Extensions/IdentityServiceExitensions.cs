using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BestKalas.Extensions
{
    public  static class IdentityServiceExitensions
    {
        //token
        public static IServiceCollection addIdentityservice(this IServiceCollection Services, IConfiguration Configuration)
        {
         Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("Tokenkey").ToString())),
                    ValidateIssuer = true,
                    ValidateAudience = false,

                };
            });
            return Services;
        }
    }
}
