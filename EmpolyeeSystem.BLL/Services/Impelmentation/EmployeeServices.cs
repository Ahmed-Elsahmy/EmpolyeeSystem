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

        public bool Delete(int id)
        {
            var result = employeeRepo.GetById(id);

            return employeeRepo.Delete(id);
        }

        public bool Edit(EditEmpVM editemp)
        {

            try
            {
                var existingEmployee = employeeRepo.GetById(editemp.id);
                if (existingEmployee != null)
                {
                    if (editemp.ImageName != null)
                    {
                        editemp.image = UploadImage.UploadFile("Profile", editemp.ImageName);
                    }


                    existingEmployee = Mapper.Map(editemp, existingEmployee);

                    employeeRepo.Edit(existingEmployee);
                    employeeRepo.SaveChanges();
                    return true;
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
            return employeeRepo.GetById(id);
        }
    }

}
