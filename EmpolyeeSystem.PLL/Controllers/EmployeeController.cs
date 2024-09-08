using AutoMapper;
using EmpolyeeSystem.BLL.Helper;
using EmpolyeeSystem.BLL.ModelVM.DepartmentVM;
using EmpolyeeSystem.BLL.ModelVM.EmpolyeeVM;
using EmpolyeeSystem.BLL.Services.Abstraction;
using EmpolyeeSystem.BLL.Services.Impelmentation;
using EmpolyeeSystem.DAl.Entities;
using EmpolyeeSystem.DAl.Repo.Abstraction;
using EmpolyeeSystem.DAl.Repo.Impelemntation;
using Microsoft.AspNetCore.Mvc;

namespace EmpolyeeSystem.PLL.Controllers
{
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
            if (emp == null)
            {
                return NotFound();
            }
            var model = Mapper.Map<EditEmpVM>(emp);
            model.Departments = departmentServices.getallDepts();
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(EditEmpVM employee)
        {
            if (ModelState.IsValid)
            {
                if (employee.Image != null)
                {
                    var filename = UploadImage.UploadFile("Profile",employee.Image);
                    employee.image = filename;
                }
                var isUpdate = employeeServices.Edit(employee);
                if((bool)isUpdate)
                {
                    return RedirectToAction("Index", "Employee");

                }
            }
            employee.Departments = departmentServices.getallDepts();
            return View(employee);
        }
    }
}
