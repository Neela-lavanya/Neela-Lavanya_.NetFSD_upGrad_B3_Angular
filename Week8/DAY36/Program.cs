using WebApplication4.Data;
using WebApplication4.Repositories;

namespace WebApplication4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ✅ Register Services
            builder.Services.AddSingleton<DapperContext>();   // better as singleton
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // ✅ Middleware
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();   // ✅ correct (instead of MapStaticAssets)

            app.UseRouting();

            app.UseAuthorization();

            // ✅ Default Route (change to Student)
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Student}/{action=StudentsWithCourse}/{id?}"
            );

            app.Run();
        }
    }
}