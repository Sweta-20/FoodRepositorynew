using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodRepository.Models
{
    public class UserItem
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("User")]
        public int uid { get; set; }
        [ForeignKey("Item")]
        public int Itemid { get; set; }

        public User User { get; set; }
      
        public Item Itemname { get; set; }

    }
}
