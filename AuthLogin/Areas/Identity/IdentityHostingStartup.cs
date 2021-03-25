using System;
using AuthLogin.Areas.Identity.Data;
using AuthLogin.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(AuthLogin.Areas.Identity.IdentityHostingStartup))]
namespace AuthLogin.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuthLoginContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AuthLoginContextConnection")));

                services.AddDefaultIdentity<AuthLoginUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                })
                    .AddEntityFrameworkStores<AuthLoginContext>();
            });
        }
    }
}