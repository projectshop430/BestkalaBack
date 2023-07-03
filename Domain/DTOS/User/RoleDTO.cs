using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Type.Type;
using System.Xml.Linq;

namespace Domain.DTOS.User
{
    public class RoleDTO
    {
       

        [Display(Name = "کاربری")]
        [Required(ErrorMessage = "لطفا {0} نام کاربری وارد کنید")]
        [MaxLength(100, ErrorMessage = "حداکثر {1} را وارد کنید")]
        public string Namerole { get; set; }


        [Display(Name = "صفحات یا عملیات")]
        [Required(ErrorMessage = "لطفا {0} نام کاربری وارد کنید")]
        [MaxLength(100, ErrorMessage = "حداکثر {1} را وارد کنید")]
        public string source { get; set; }

        public bool IsShow { get; set; }

        public RoleDTO(string namerole, string source, bool isShow)
        {
            Namerole = namerole;
            this.source = source;
            IsShow = isShow;
        }
    }
}
