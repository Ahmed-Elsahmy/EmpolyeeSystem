using EmpolyeeSystem.BLL.ModelVM.DepartmentVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpolyeeSystem.BLL.Services.Abstraction
{
    public interface IDepartmentServices
    {
        public List<GetallDeptVM> getallDepts();
        public bool Create(CreateDeptVM createDeptVM);
    }
}
