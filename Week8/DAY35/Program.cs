using WebApplication4.Data;
using WebApplication4.Repositories;

namespace WebApplication4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ✅ ADD THIS
            builder.Services.AddScoped<DapperContext>();

            // ✅ ALREADY THERE
            builder.Services.AddScoped<IContactRepository, ContactRepository>();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Contact}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}