using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using StockManagement.Application.Interfaces;
using StockManagement.Application.Services;
using StockManagement.Infrastructure.Database;
using System.Net;
using System.Net.Mail;

namespace StockManagement.Web.DependencyInjections
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddAndConfigureBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            return services;
        }

        public static IServiceCollection AddAndConfigureDbContext(this IServiceCollection services, string? connectionString)
        {
            services.AddDbContext<StockContext>(b => 
                b.UseSqlServer(connectionString)
            );
            return services;
        }

        public static IServiceCollection AddAndConfigureAuthentication(this IServiceCollection services) 
        {
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => {
                    options.LoginPath = "/Security/Auth/Login";
                    options.AccessDeniedPath = "/Security/Auth/Login";
                    options.LogoutPath = "/Security/Auth/Logout";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                });
            return services;
        }

        public static IServiceCollection AddAndConfigureSmtp(
            this IServiceCollection services, SmtpConfig? config
        )
        {
            if(config ==null || string.IsNullOrWhiteSpace(config.Host) || config.Port == null)
            {
                throw new Exception("Missing Smtp Configuration");
            }
            services.AddScoped(_ => new SmtpClient
            {
                Host = config.Host,
                Port = config.Port.Value,
                Credentials = new NetworkCredential(config.Username, config.Password),
                EnableSsl = true,
            });
            return services;
        }
    }

    public class SmtpConfig
    {
        public string? Host { get; set; }
        public int? Port { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
