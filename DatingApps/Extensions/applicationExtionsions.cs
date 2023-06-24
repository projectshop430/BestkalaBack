using Data.Context;
using BestKalas.Services.Implemention;
using BestKalas.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace BestKalas.Extensions
{
    //Database 
    public static class applicationExtionsions
    {
        public static IServiceCollection addapplicationservice(this IServiceCollection Services, IConfiguration Configuration)
        {
            Services.AddScoped<ITokenServices, TokenServices>();
            Services.AddDbContext<BestKalaContext>(option =>
            {
               

                option.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString"));
            },



              ServiceLifetime.Transient);
            Services.AddControllersWithViews();
            return Services;
        }
    }
}
