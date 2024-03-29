﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Type.Type;

namespace Domain.Entitis.user
{
    public class Roles
    {
        [Key]
        public int idRole { get; set; }

        [Display(Name = "کاربری")]
        [Required(ErrorMessage = "لطفا {0} نام کاربری وارد کنید")]
        [MaxLength(100, ErrorMessage = "حداکثر {1} را وارد کنید")]
        public  string Namerole { get; set; }


        [Display(Name = "صفحات یا عملیات")]
        [Required(ErrorMessage = "لطفا {0} نام کاربری وارد کنید")]
        [MaxLength(100, ErrorMessage = "حداکثر {1} را وارد کنید")]
        public string source { get; set; }

        public bool IsShow { get; set; }

    }
}
