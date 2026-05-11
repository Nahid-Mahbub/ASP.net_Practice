using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using practice.Web.Codes;
using practice.Web.Data;

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

app.Run();
