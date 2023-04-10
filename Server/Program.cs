using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using SmartphonePortal_Vervoort_Wagner.Server.Data;
using SmartphonePortal_Vervoort_Wagner.Server.Models;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using SmartphonePortal_Vervoort_Wagner.Server.Mappers;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;
using Microsoft.OpenApi.Models;
using System.Reflection;
using SmartphonePortal_Vervoort_Wagner.Server.Services;
using IProfileService = SmartphonePortal_Vervoort_Wagner.Server.Interfaces.IProfileService;
using SmartphonePortal_Vervoort_Wagner.Server.Interfaces;

var builder = WebApplication.CreateBuilder(args);

#region DB connection
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

#endregion

#region Identity Server And Auth
// add IdentityRole to use Roles
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentityServer()
.AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options =>
{
    options.IdentityResources["openid"].UserClaims.Add("role");
    options.ApiResources.Single().UserClaims.Add("role");
});

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("role");
builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

#endregion

// mvc things
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRazorPages();

// swagger stuff
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Smartphone Portal API",
        Description = "API for our Smartphone Portal application"
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

#region Dependency Injection

// services
builder.Services.AddTransient<IProfileService, ProfileService>();
builder.Services.AddTransient<IProcessorService, ProcessorService>();
builder.Services.AddTransient<ISmartphoneService, SmartphoneService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IManufacturerService, ManufacturerService>();

// mappers
builder.Services.AddTransient<IMapper<Processor, ProcessorViewModel>, ProcessorMapper>();
builder.Services.AddTransient<IMapper<Comment, CommentViewModel>, CommentMapper>();
builder.Services.AddTransient<IMapper<Rating, RatingViewModel>, RatingMapper>();
builder.Services.AddTransient<IMapper<Review, ReviewViewModel>, ReviewMapper>();
builder.Services.AddTransient<IMapper<ApplicationUser, ProfileViewModel>, ProfileMapper>();
builder.Services.AddTransient<IMapper<Smartphone, SmartphoneViewModel>, SmartphoneMapper>();
builder.Services.AddTransient<IMapper<Picture, PictureViewModel>, PictureMapper>();
builder.Services.AddTransient<IMapper<Manufacturer, ManufacturerViewModel>, ManufacturerMapper>();
builder.Services.AddTransient<IMapper<Category, CategoryViewModel>, CategoryMapper>();

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

// more swagger stuff
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

#region Middleware and what not
var serviceScope = app.Services.GetService<IServiceScopeFactory>()?.CreateScope();
var context = serviceScope?.ServiceProvider.GetRequiredService<ApplicationDbContext>();
context?.Database.EnsureCreated();

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllers();
});
app.MapFallbackToFile("index.html");

#endregion

app.Run();
