using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCDemo.Data;
using MVCDemo.Models;
using MVCDemo.Models.Domain;

namespace MVCDemo.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MVCDemoDbContext _datacontext;

        public EmployeesController(MVCDemoDbContext datacontext)
        {
            _datacontext = datacontext;
        }



        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await _datacontext.Employees.ToListAsync();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Email = addEmployeeRequest.Email,
                Salary = addEmployeeRequest.Salary,
                DateOfBirth = addEmployeeRequest.DateOfBirth,
                Department = addEmployeeRequest.Department
            };

            await _datacontext.Employees.AddAsync(employee);
            await _datacontext.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var employee = await _datacontext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee != null)
            { 
                var viewModel = new UpdateEmployeeViewModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    Salary = employee.Salary,
                    DateOfBirth = employee.DateOfBirth,
                    Department = employee.Department
                };
                return await Task.Run(() => View("View", (viewModel)));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateEmployeeViewModel model)
        {
            var employee = await _datacontext.Employees.FindAsync(model.Id);

            if(employee != null)
            {
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.DateOfBirth = model.DateOfBirth;
                employee.Salary = model.Salary;
                employee.Department = model.Department;


                await _datacontext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(UpdateEmployeeViewModel model)
        {
            var employee = await _datacontext.Employees.FindAsync(model.Id);
            if(employee != null)
            {
                _datacontext.Employees.Remove(employee);
                await _datacontext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
    }
}
