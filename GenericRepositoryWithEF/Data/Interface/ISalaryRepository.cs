using GenericRepositoryWithEF.Domain;

namespace GenericRepositoryWithEF.Data.Interface
{
    public interface ISalaryRepository: IRepository<Salary>
    {
    }
    public interface IReadOnlySalaryRepository : IReadOnlyRepository<Salary>
    {
    }
}
