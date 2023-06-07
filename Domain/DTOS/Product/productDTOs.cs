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
        public string avatar { get; private set; }

        [Display(Name = "نام")]
        public string Name { get; private set; }

        [Display(Name = "قیمت")]
        public float price { get; private set; }

        [Display(Name = "دسته بندی")]
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
