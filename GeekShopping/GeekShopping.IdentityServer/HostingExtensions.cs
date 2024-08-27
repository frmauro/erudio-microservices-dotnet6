using Serilog;

namespace GeekShopping.IdentityServer
{
    internal static class HostingExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            // uncomment if you want to add a UI
            builder.Services.AddRazorPages();

            //builder.Services
            //        .AddIdentity<ApplicationUser, IdentityRole>()
            //        .AddEntityFrameworkStores<MySqlContext>()
            //        .AddDefaultTokenProviders();

            builder.Services.AddIdentityServer()
            .AddInMemoryIdentityResources(Config.IdentityResources)
            .AddInMemoryApiScopes(Config.ApiScopes)
            .AddInMemoryClients(Config.Clients)
            .AddTestUsers(TestUsers.Users);
            //.AddDeveloperSigningCredential();

            //builder.Services.AddScoped<IDbInitializer, DbInitializer>();

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseSerilogRequestLogging();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // uncomment if you want to add a UI
            app.UseStaticFiles();
            app.UseRouting();

            app.UseIdentityServer();

            // uncomment if you want to add a UI
            app.UseAuthorization();
            app.MapRazorPages().RequireAuthorization();

            return app;
        }


        public static WebApplication ConfigureDb(this WebApplication app)
        {

            return app;
        }



    }
}
