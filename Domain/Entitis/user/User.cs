using Domain.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Domain.Rule;
using System.Security.Principal;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entitis.user
{
    public class User 
    {
    
        //propety user
        [Key]
        public int UserId { get; set; }

        [Display(Name ="ایمیل")]
        [Required(ErrorMessage ="لطفا {0}  را وارد کنید")]
        [MaxLength(100,ErrorMessage ="حداکثر {1} کارکتر مجاز می باشد")]
        public string Email { get;  set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0}  را وارد کنید")]
        [MaxLength(100, ErrorMessage = "حداکثر {1} کارکتر مجاز می باشد")]
        public string Password { get;  set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0}  را وارد کنید")]
        [MaxLength(100, ErrorMessage = "حداکثر {1} کارکتر مجاز می باشد")]
        public string Usernamea { get;  set; }

        [Display(Name = "شماره موبایل")]
        [MaxLength(11, ErrorMessage = "حداکثر {1} کارکتر مجاز می باشد")]
        public string? Phonenumbera { get;  set; }

        [Display(Name = "آواتار")]
        [MaxLength(11, ErrorMessage = "حداکثر {1} کارکتر مجاز می باشد")]
        public string Avatar { get;  set; }
        [Display(Name = "ایمیل فعال باشد")]
        public bool IsEmailActive { get; set; }
        [Display(Name = "تاریخ ثبت نام")]
        public DateTime RegisterDate { get;  set; }
        
        public bool isdeleted { get; set; }
       
       

    }

    }

