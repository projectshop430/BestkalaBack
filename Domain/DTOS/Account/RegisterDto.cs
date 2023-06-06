using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.DTOS.Account
{
    public class RegisterDto
    {


        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0}  را وارد کنید")]
        [MaxLength(100, ErrorMessage = "حداکثر {1} کارکتر مجاز می باشد")]
        public string Email { get; private set; }
        [Display(Name = "پسورد")]
        [Required(ErrorMessage = "لطفا {0}  را وارد کنید")]
        [MaxLength(100, ErrorMessage = "حداکثر {1} کارکتر مجاز می باشد")]
        public string password { get; private set; }

        [Display(Name = " تکرار کلمه پسورد")]
        [Required(ErrorMessage = "لطفا {0}  را وارد کنید")]
        [MaxLength(100, ErrorMessage = "حداکثر {1} کارکتر مجاز می باشد")]
        [Compare(nameof(password), ErrorMessage = "کلمه عبور و تکرا آن یکسان نمی بشاد")]
        public string Repeatpassword { get; private set; }
        public RegisterDto(string email, string password, string repeatpassword)
        {
            Email = email;
            this.password = password;
            Repeatpassword = repeatpassword;
        }
    }
}
