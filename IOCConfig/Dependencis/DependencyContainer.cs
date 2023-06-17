using Application.Convertors;
using Application.Security.PassordHelper;
using Application.Senders.Mail;

using Application.Services.Implemention;
using Application.Services.Interface;
using Data.Repository;
using Domain.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCConfig.Dependencis
{
    public class DependencyContainer
    {
        public static void callDependencyContainer(IServiceCollection services)
        {
            
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IViewRender, RenderViewToString>();
            services.AddScoped<IPasswordHelper, PasswordHelper>();
            services.AddScoped<ISendmail,SendMail>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IproductRepository, ProductRepository>();

            services.AddScoped<IFavoriteRepository, FavoriteRepository>();
            services.AddScoped<IFavoriteService, FavoriteService>();

        }
    }
}
