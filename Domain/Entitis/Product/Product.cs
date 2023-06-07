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
        public string avatar { get;  set; }

        [Display(Name = "نام")]
        public string Name { get;  set; }

        [Display(Name = "قیمت")]
        public float price { get;  set; }

        [Display(Name = "دسته بندی")]
        public string category { get;  set; }

    }
}
