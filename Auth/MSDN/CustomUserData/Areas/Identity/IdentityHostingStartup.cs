using System;
using CustomUserData.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CustomUserData.Areas.Identity.IdentityHostingStartup))]
namespace CustomUserData.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<CustomUserDataIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("CustomUserDataIdentityDbContextConnection")));

                services.AddDefaultIdentity<CustomUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<CustomUserDataIdentityDbContext>();
            });
        }
    }
}