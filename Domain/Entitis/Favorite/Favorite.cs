using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitis.Favorite
{
    public class Favorite
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "شناسه کالا")]
      
        public int productId { get; set; }


        [Display(Name = "تخفیف وِیژه")]
        
        public float discount { get; set; }
    }
}
