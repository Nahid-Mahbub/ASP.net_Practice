using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using practice.Web.Codes;
using practice.Web.Data;
using Serilog;
using Autofac;
using Autofac.Extensions.DependencyInjection;

// Bootstrap Logger Configuration
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("Logs/log-.log", rollingInterval: RollingInterval.Day) // Daily log files
    .CreateBootstrapLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));

    #region Dependency Injection Lifetime & Keyed Services Configuration

    // ==============================
    // Dependency Injection Lifetimes
    // ==============================

    // Scoped:
    // প্রতি HTTP Request এ একবার Instance তৈরি হয়।
    // Database Context বা Request-based Service এর জন্য সবচেয়ে ভালো।
    //builder.Services.AddScoped<IMembership, ImprovedMembership>();

    // Singleton:
    // Application চলাকালীন পুরো Lifetime এ একই Instance ব্যবহার হয়।
    // Shared Configuration বা Heavy Service এর জন্য উপযোগী।
    //builder.Services.AddSingleton<IMembership, ImprovedMembership>();

    // Transient:
    // যতবার Service Call হবে ততবার নতুন Instance তৈরি হবে।
    // Lightweight ও Stateless Service এর জন্য ভালো।
    //builder.Services.AddTransient<IMembership, ImprovedMembership>();



    // ==========================================
    // Keyed Services (Same Interface, Multiple Implementations)
    // ==========================================

    // একই Interface এর একাধিক Implementation আলাদা Key দিয়ে Register করা যায়।

    builder.Services.AddKeyedScoped<IMembership, Membership>("Setup 1");

    //builder.Services.AddKeyedScoped<IMembership, ImprovedMembership>("Setup 2");



    // ==========================================
    // Parameterized Dependency Injection
    // ==========================================

    // Constructor এ Custom Parameter পাঠানোর জন্য Factory Method ব্যবহার করা হয়।

    //builder.Services.AddScoped<IMembership, ImprovedMembership>(serviceProvider =>
    //{
    //    return new ImprovedMembership("Trailing parameter");
    //});

    // Keyed Scoped Service Register করার সময়ও Factory Method ব্যবহার করা যায়।

    builder.Services.AddKeyedScoped<IMembership>("Setup 2", (serviceProvider, key) =>
    {
        return new ImprovedMembership("Trailing parameter");
    });



    #endregion

    #region serilog configuration
    
    // Controller Errors, Database Exceptions addscope o korte hocche nh internali kore nicche
    builder.Host.UseSerilog((context, lc) => lc
        .MinimumLevel.Debug() // Set the minimum log level to Debug for all logs
        .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning) // Override the log level for Microsoft namespaces to Warning
        .Enrich.FromLogContext() // Enrich logs with contextual information (e.g., request details)
        .ReadFrom.Configuration(context.Configuration)); // Read Serilog configuration from appsettings.json or other configuration sources

    #endregion

    #region AutoFac Configuration

    //builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()); // Override the default service provider factory with Autofac
    //builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    //{
        // Register your services with Autofac here
        //containerBuilder.RegisterType<ImprovedMembership>()
        //.As<Membership>()
        //.InstancePerLifetimeScope();

        // ASP.NET Core DI vs Autofac Lifetime Mapping

        // AddSingleton()  => SingleInstance()
        // One instance for the entire application lifetime

        // AddScoped()     => InstancePerLifetimeScope()
        // One instance per request / lifetime scope

        // AddTransient() => InstancePerDependency()
        // New instance every time it is resolved
    //});

    #endregion

    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<ApplicationDbContext>();
    builder.Services.AddControllersWithViews();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseMigrationsEndPoint();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseRouting();

    app.UseAuthorization();

    app.MapStaticAssets();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
        .WithStaticAssets();

    app.MapRazorPages()
       .WithStaticAssets();

    Log.Information("Application Starting Up");
    app.Run();
}
catch (Exception ex)
{
    // Log the exception (you can use a logging framework here)
    Console.WriteLine($"An error occurred: {ex.Message}");
    Log.Fatal("Application terminated unexpectedly: {ExceptionMessage}", ex.Message);
}
finally
{
    Log.CloseAndFlush(); // Ensure all logs are flushed before the application exits, batch by batch saved in buffer then flushed to the log file.
}