using GenericRepositoryWithEF.Data.Interface;
using GenericRepositoryWithEF.Domain;
using GenericRepositoryWithEF.Service.ViewModel;

namespace GenericRepositoryWithEF.Service
{
    public interface IEmployeeService
    {
        Task<int> Add(EmployeeViewModel employeeDTO);
        Task Update(EmployeeViewModel model, int id);
        Task<Employee> GetById(int id);
        Task<IEnumerable<Employee>> GetAll();
        Task Delete(int id);
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IReadOnlyEmployeeRepository _readOnlyEmployeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository
            , IReadOnlyEmployeeRepository readOnlyEmployeeRepository)
        {
            _employeeRepository = employeeRepository;
            _readOnlyEmployeeRepository = readOnlyEmployeeRepository;
        }
        public async Task<int> Add(EmployeeViewModel model)
        {
            Employee employee = new Employee
            {
                Address = model.Address,
                Name = model.Name,
                Active = true
            };
            await _employeeRepository.AddAsync(employee);
            await _employeeRepository.SaveAsync();
            return employee.Id;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            IEnumerable<Employee> employees = await _readOnlyEmployeeRepository.GetAll();
            return employees;
        }

        public async Task<Employee> GetById(int id)
        {
            Employee employee = await _readOnlyEmployeeRepository.Get(x => x.Id == id);
            return employee;
        }

        public async Task Update(EmployeeViewModel model, int id)
        {
            if (!await _readOnlyEmployeeRepository.AnyAsync(x => x.Id == id))
            {
                throw new Exception("Invalid Employee");
            }
            Employee employee = await _employeeRepository.GetByIdAsync(id);
            employee.Address = model.Address;
            employee.Name = model.Name;
            _employeeRepository.Update(employee);
            await _employeeRepository.SaveAsync();
        }

        public async Task Delete(int id)
        {
            if (!await _readOnlyEmployeeRepository.AnyAsync(x => x.Id == id))
            {
                throw new Exception("Invalid Employee");
            }
            Employee employee = await _employeeRepository.GetByIdAsync(id);
             _employeeRepository.Delete(employee);
            await _employeeRepository.SaveAsync();
        }
    }
}
