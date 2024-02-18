using GenericRepositoryWithEF.Domain;

namespace GenericRepositoryWithEF.Data.Interface
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
    }

    public interface IReadOnlyEmployeeRepository : IReadOnlyRepository<Employee>
    {
    }
}
