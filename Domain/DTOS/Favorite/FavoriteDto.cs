using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.DTOS.Favorite
{
    public class FavoriteDto
    {

        [Key]
        public int id { get; set; }

        [Display(Name = "شناسه کالا")]
     
        public int productId { get; set; }
        [Display(Name = "تخفیف وِیژه")]
       
        public float discount { get; set; }



        public FavoriteDto(int productId, float discount)
        {
           
            this.productId = productId;
            this.discount = discount;
        }
    }
}
