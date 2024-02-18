using GenericRepositoryWithEF.Data.Interface;
using GenericRepositoryWithEF.Data.Repository;
using GenericRepositoryWithEF.Service;

namespace GenericRepositoryWithEF
{
    public static class DependencyResolution
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IReadOnlyEmployeeRepository, ReadOnlyEmployeeRepository>();


            services.AddScoped<ISalaryRepository, SalaryRepository>();
            services.AddScoped<IReadOnlySalaryRepository, ReadOnlySalaryRepository>();
            return services;
        }
    }
}
