using AutoMapper;
using EmpolyeeSystem.BLL.Helper;
using EmpolyeeSystem.BLL.ModelVM.DepartmentVM;
using EmpolyeeSystem.BLL.ModelVM.EmpolyeeVM;
using EmpolyeeSystem.BLL.Services.Abstraction;
using EmpolyeeSystem.BLL.Services.Impelmentation;
using EmpolyeeSystem.DAl.Entities;
using EmpolyeeSystem.DAl.Repo.Abstraction;
using EmpolyeeSystem.DAl.Repo.Impelemntation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmpolyeeSystem.PLL.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices employeeServices;
        private readonly IDepartmentServices departmentServices;

        public IMapper Mapper { get; }

        public EmployeeController(IEmployeeServices employeeServices , IDepartmentServices  departmentServices ,IMapper mapper)
        {
            this.employeeServices = employeeServices;
            this.departmentServices = departmentServices;
            Mapper = mapper;
        }

        public IActionResult Index()
        {
            
            var data = employeeServices.Getall();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
             CreateEmpVM empVM = new CreateEmpVM();
            empVM.Departments = departmentServices.getallDepts();
            return View(empVM);
        }
        [HttpPost]
        public IActionResult Create(CreateEmpVM createEmpVM)
        {
            if (ModelState.IsValid)
            {
                if (employeeServices.Create(createEmpVM))
                {
                    return RedirectToAction("Index", "Employee");

                }
                return View(createEmpVM);
            }
          
            return View(createEmpVM);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var emp = employeeServices.GetByid(id);
            var model = Mapper.Map<EditEmpVM>(emp);
            model.Departments = departmentServices.getallDepts();
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(EditEmpVM employee)
        {
            var data = employeeServices.Edit(employee);
            employee.Departments = departmentServices.getallDepts();
            return RedirectToAction("Index", "Employee");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = employeeServices.GetByid(id);
            if (data == null)
            {
                return NotFound();
            }
            var model = Mapper.Map<DeleteEmpVM>(data);

            return View(model);
        }
        [HttpPost]
        public IActionResult DeleteEmp(int Id)
        {
            try
            {
                if (employeeServices.Delete(Id))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMessage = "Error deleting the employee.";
                    var employee = employeeServices.GetByid(Id);
                    if (employee == null)
                    {
                        return NotFound();
                    }

                    // Map the employee entity back to DeleteEmployeeVM
                    var model = Mapper.Map<DeleteEmpVM>(employee);
                    return View("Index", "Employee");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                var employee = employeeServices.GetByid(Id);
                if (employee == null)
                {
                    return NotFound();
                }

                // Map the employee entity back to DeleteEmployeeVM
                var model = Mapper.Map<DeleteEmpVM>(employee);
                return View("Index", "Employee");
            }

        }
    }
}
