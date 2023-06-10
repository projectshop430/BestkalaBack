using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitis.Product
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "آواتار")]
        [Required(ErrorMessage = "لطفا {0}  را وارد کنید")]

        public string avatar { get;  set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0}  را وارد کنید")]

        public string Name { get;  set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا {0}  را وارد کنید")]

        public float price { get;  set; }

        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = "لطفا {0}  را وارد کنید")]

        public string category { get;  set; }

    }
}
