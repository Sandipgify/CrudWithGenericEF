using GenericRepositoryWithEF.Service;
using GenericRepositoryWithEF.Service.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepositoryWithEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeViewModel model)
        {
            return Ok(await _employeeService.Add(model));
        }
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _employeeService.GetById(id));
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _employeeService.GetAll());
        }
        [HttpPut]
        public async Task<IActionResult> Update(EmployeeViewModel model, int id)
        {
            await _employeeService.Update(model, id);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.Delete(id);
            return NoContent();
        }

    }
}
