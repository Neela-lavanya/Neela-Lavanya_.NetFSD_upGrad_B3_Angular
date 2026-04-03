using Microsoft.EntityFrameworkCore;

using WebApplication2.Models;
using WebApplication2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add MVC
builder.Services.AddControllersWithViews();


// 🔹 CONTACT APP (Dependency Injection)
builder.Services.AddSingleton<IContactService, ContactService>();


// 🔹 MOVIE APP (Entity Framework Core)
builder.Services.AddDbContext<MovieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();


// Middleware
app.UseStaticFiles();
app.UseRouting();


// ✅ DEFAULT ROUTE (STARTING PAGE)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Contact}/{action=ShowContacts}/{id?}");


// 👉 NOTE:
// Contact Page → /Contact/ShowContacts
// Movie Page → /Movie/Index (via navbar link)


app.Run();