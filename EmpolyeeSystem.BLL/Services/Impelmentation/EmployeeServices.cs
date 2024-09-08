using AutoMapper;
using EmpolyeeSystem.BLL.Helper;
using EmpolyeeSystem.BLL.ModelVM.EmpolyeeVM;
using EmpolyeeSystem.BLL.Services.Abstraction;
using EmpolyeeSystem.DAl.Entities;
using EmpolyeeSystem.DAl.Repo.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EmpolyeeSystem.BLL.Services.Impelmentation
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepo employeeRepo;

        public EmployeeServices(IEmployeeRepo employeeRepo, IMapper mapper)
        {
            this.employeeRepo = employeeRepo;
            Mapper = mapper;
        }

        public IMapper Mapper { get; }

        public bool Create(CreateEmpVM emp)
        {
         emp.image =   UploadImage.UploadFile("Profile" , emp.Image);
            var Result = Mapper.Map<Employee>(emp);
           return employeeRepo.Create(Result);
        }

        public bool Edit(EditEmpVM editemp)
        {
            try
            {
                var emp = employeeRepo.GetById(editemp.id);
                if (emp != null)
                {
                    if (emp.image != null)
                    {
                        {
                            emp.image = UploadImage.UploadFile("Profile", editemp.Image);
                        }
                        emp = Mapper.Map(editemp, emp);
                        employeeRepo.Edit(emp);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return false;
                   
            }

        }

        public List<GetallEmpVM> Getall()
        {
            var result = employeeRepo.GetAll().ToList();
            var newData = Mapper.Map<List<GetallEmpVM>>(result);
                return newData;
        }

        public Employee GetByid(int id)
        {
            var emp = employeeRepo.GetById(id);
            if (emp == null)
            {
                throw new Exception("Emp Not Found");
            }
            return emp;
        }
    }

}
