using AutoMapper;
using EmpolyeeSystem.BLL.ModelVM.DepartmentVM;
using EmpolyeeSystem.BLL.ModelVM.EmpolyeeVM;
using EmpolyeeSystem.DAl.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EmpolyeeSystem.BLL.Mapping
{
    public class DomainProfile :Profile
    {
        public DomainProfile()
        {

            // From Entity To VM (Retreive)
            CreateMap<Employee, GetallEmpVM>();
            CreateMap<Department , GetallDeptVM>();
            // Fro
            CreateMap<CreateEmpVM, Employee>();
            CreateMap<CreateDeptVM, Department>();
            CreateMap<Employee, EditEmpVM>().ReverseMap();
        }
    }
}
