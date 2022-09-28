using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using SmartphonePortal_WV_KW.core.Services;
using SmartphonePortal_WV_KW.Server.Data;
using SmartphonePortal_WV_KW.Server.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region DB + Auth

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

#endregion

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

#region DI

builder.Services.AddTransient<ISmartphoneService, SmartphoneService>();
builder.Services.AddTransient<ISmartphoneDetailsService, SmartphoneDetailsService>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
