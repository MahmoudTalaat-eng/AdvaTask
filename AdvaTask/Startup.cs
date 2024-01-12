using AdvaTask.Bll.Employees.Repository;

namespace AdvaTask
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            // Other services

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }


    }

}
