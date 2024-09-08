using AutoMapper;
using EmpolyeeSystem.BLL.ModelVM.DepartmentVM;
using EmpolyeeSystem.BLL.ModelVM.EmpolyeeVM;
using EmpolyeeSystem.BLL.Services.Abstraction;
using EmpolyeeSystem.DAl.Entities;
using EmpolyeeSystem.DAl.Repo.Abstraction;
using EmpolyeeSystem.DAl.Repo.Impelemntation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpolyeeSystem.BLL.Services.Impelmentation
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IDepartmentRepo departmentRepo;

        public DepartmentServices(IDepartmentRepo departmentRepo, IMapper mapper)
        {
            this.departmentRepo = departmentRepo;
            Mapper = mapper;
        }

        public IMapper Mapper { get; }

        public bool Create(CreateDeptVM createDeptVM)
        {
            var result = Mapper.Map<Department>(createDeptVM);
            return departmentRepo.Create(result);
        }

        public List<GetallDeptVM> getallDepts()
        {
                 var result = departmentRepo.GetAll().ToList();
            var Newdata = Mapper.Map<List<GetallDeptVM>>(result);
            return Newdata;
        }

    }
}
