using GenericRepositoryWithEF.Data.Interface;
using GenericRepositoryWithEF.Data.Repository;

namespace GenericRepositoryWithEF
{
    public static class DependencyResolution
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
