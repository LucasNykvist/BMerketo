using Bmerketo.Contexts;
using Bmerketo.Models.Identity;
using Bmerketo.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("IdentitySql")));
builder.Services.AddScoped<SeedService>();
builder.Services.AddScoped<AuthService>();

builder.Services.AddIdentity<CustomIdentityUser, IdentityRole>(x =>
{
	x.SignIn.RequireConfirmedAccount= false;
	x.User.RequireUniqueEmail= true;
	x.Password.RequiredLength= 8;
}).AddEntityFrameworkStores<IdentityContext>();

builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<UserService>();

var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
