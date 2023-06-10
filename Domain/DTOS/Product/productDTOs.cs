using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.DTOS.Product
{
    public class productDTOs
    {

       
        [Display(Name = "آواتار")]
        [Required(ErrorMessage = "لطفا {0}  را وارد کنید")]
        public string avatar { get; private set; }

       
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0}  را وارد کنید")]
        public string Name { get; private set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا {0}  را وارد کنید")]
        public float price { get; private set; }

        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = "لطفا {0}  را وارد کنید")]
        public string category { get; private set; }

        public productDTOs(string avatar, string name, float price, string category)
        {
            this.avatar = avatar;
            Name = name;
            this.price = price;
            this.category = category;
        }

    }
}
