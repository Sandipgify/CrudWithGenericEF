using GenericRepositoryWithEF.Data.Interface;
using GenericRepositoryWithEF.Domain;

namespace GenericRepositoryWithEF.Data.Repository
{
    public class SalaryRepository:Repository<Salary>, ISalaryRepository
    {
        public SalaryRepository(ApplicationDbContext context):base(context)
        {
            
        }
    }

    public class ReadOnlySalaryRepository : ReadOnlyRepository<Salary>, IReadOnlySalaryRepository
    {
        public ReadOnlySalaryRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
