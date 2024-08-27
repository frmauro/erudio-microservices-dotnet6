using GeekShopping.IdentityServer;
using GeekShopping.IdentityServer.Initializer;
using GeekShopping.IdentityServer.Model;
using GeekShopping.IdentityServer.Model.Context;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
        .Enrich.FromLogContext()
        .ReadFrom.Configuration(ctx.Configuration), true);

    //var connection = builder.Configuration["MySqlConnection:MySqlConnectionString"];
    //builder.Services.AddDbContext<MySqlContext>(options => options.UseMySql(connection, new MySqlServerVersion(new Version(5, 7))));

    //builder.Services
    //    .AddIdentity<ApplicationUser, IdentityRole>()
    //    .AddEntityFrameworkStores<MySqlContext>()
    //    .AddDefaultTokenProviders();


    var app = builder
        .ConfigureServices()
        .ConfigurePipeline();

    var serviceProvider = builder.Services.BuildServiceProvider();

    //var dbInicializer = serviceProvider.GetService<IDbInitializer>();
    //dbInicializer.Initialize();

    //if (app.Environment.IsDevelopment())
    //{
    //}
    //app.UseHttpsRedirection();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}