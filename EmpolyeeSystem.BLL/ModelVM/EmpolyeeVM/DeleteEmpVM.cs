﻿using EmpolyeeSystem.BLL.ModelVM.DepartmentVM;
using EmpolyeeSystem.DAl.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpolyeeSystem.BLL.ModelVM.EmpolyeeVM
{
    public class DeleteEmpVM
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Age Is Required")]
        [Range(10, 50)]
        public int Age { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Salary Is Required")]
        public double Salary { get; set; }
        public string? image { get; set; }
        [ForeignKey("Department")]
        public int? DeptId { get; set; }
        public IFormFile? ImageName { get; set; }
        public Department? Department { get; set; }
    }
}
