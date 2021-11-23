using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UCP_PAW_1.Areas.Identity.Data;
using UCP_PAW_1.Data;

[assembly: HostingStartup(typeof(UCP_PAW_1.Areas.Identity.IdentityHostingStartup))]
namespace UCP_PAW_1.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<UCPDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("UCPDbContextConnection")));

                services.AddDefaultIdentity<AuthUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                })
                   .AddEntityFrameworkStores<UCPDbContext>();
            });
        }
    }
}