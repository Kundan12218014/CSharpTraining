using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodeFirstDemo.Context;

namespace CodeFirstDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeContext _employeeContext;
        EmployeeController(EmployeeContext employeeContext )
        {
            this._employeeContext = employeeContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return _employeeContext.Employees != null ?
                        View(await _employeeContext.Employees.ToListAsync()) :
                        Problem("Entity set 'EmployeeContext.Employees'  is null.");
        }
}
