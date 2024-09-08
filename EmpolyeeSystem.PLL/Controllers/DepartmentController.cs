using EmpolyeeSystem.BLL.ModelVM.DepartmentVM;
using EmpolyeeSystem.BLL.ModelVM.EmpolyeeVM;
using EmpolyeeSystem.BLL.Services.Abstraction;
using EmpolyeeSystem.BLL.Services.Impelmentation;
using EmpolyeeSystem.DAl.Repo.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace EmpolyeeSystem.PLL.Controllers
{
    public class DepartmentController : Controller
    {
        public readonly IDepartmentServices departmentServices;

        public DepartmentController(IDepartmentServices departmentServices)
        {
            this.departmentServices = departmentServices;
        }

        public IActionResult Index()
        {
            var data = departmentServices.getallDepts();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateDeptVM  createDeptVM)
        {
            if (ModelState.IsValid)
            {
                if (departmentServices.Create(createDeptVM))
                {
                    return RedirectToAction("Index", "Department");

                }
                return View(createDeptVM);
            }
                  return View(createDeptVM);
        }
    }
}
