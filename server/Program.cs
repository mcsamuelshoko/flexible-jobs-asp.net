using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using FlexibleJobs.Data;

Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateBootstrapLogger();

try
{
    Log.Information("Starting web application");
    Log.Debug("[DEBUG]Lets Goooooooooooooooo!"); //TODO: check how to use debug level logs and show in console
    Log.Warning("This is very sus!");
    Log.Verbose("This is quite verbose, young Sir"); //TODO: check on using verbose logging
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddDbContext<FlexibleJobsContext>(options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("FlexibleJobsContext")
                ?? throw new InvalidOperationException(
                    "Connection string 'FlexibleJobsContext' not found."
                )
        )
    );

    // Add services to the container.
    builder.Services.AddControllersWithViews();

    builder
        .Services.AddAuthentication()
        .AddCookie(
            /** https://learn.microsoft.com/en-us/aspnet/core/security/authentication/?view=aspnetcore-8.0 */
            CookieAuthenticationDefaults.AuthenticationScheme,
            options => builder.Configuration.Bind("CookieSettings", options)
        );
    builder.Services.AddAuthorization();
    builder.Services.AddCors();

    // logger
    builder.Host.UseSerilog();

    var app = builder.Build();

    app.UseSerilogRequestLogging();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseCors();
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
