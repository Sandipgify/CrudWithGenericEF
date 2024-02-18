using GenericRepositoryWithEF.Data.Interface;
using GenericRepositoryWithEF.Domain;

namespace GenericRepositoryWithEF.Data.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext dbContext): base(dbContext)
        {
            
        }
    }

    public class ReadOnlyEmployeeRepository : ReadOnlyRepository<Employee>, IReadOnlyEmployeeRepository
    {
        public ReadOnlyEmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
