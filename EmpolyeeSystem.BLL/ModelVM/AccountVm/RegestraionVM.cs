﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpolyeeSystem.BLL.ModelVM.AccountVm
{
    public class RegestraionVM
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email {  get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
