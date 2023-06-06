using Data.Context;
using DatingApps.Services.Implemention;
using DatingApps.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace DatingApps.Extensions
{
    //Database 
    public static class applicationExtionsions
    {
        public static IServiceCollection addapplicationservice(this IServiceCollection Services, IConfiguration Configuration)
        {
            Services.AddScoped<ITokenServices, TokenServices>();
            Services.AddDbContext<DatingAppContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString"));
            }

          
             );
            Services.AddControllersWithViews();
            return Services;
        }
    }
}
