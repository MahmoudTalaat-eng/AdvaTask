using AdvaTask.Bll.Department.Service;
using AdvaTask.Bll.Departments.Repository;
using AdvaTask.Bll.Employees.Repository;
using AdvaTask.Bll.Employees.Service;
using AdvaTask.DAL;
using Microsoft.EntityFrameworkCore;

namespace AdvaTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AdvaTaskContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString(@"AdvaTaskConnection"));
            }, ServiceLifetime.Scoped);

            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();

            var app = builder.Build();
            

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
