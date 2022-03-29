using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodRepository.Models
{
    public class User
    {
        [Key]
        public int userid { get; set; }
        public string username { get; set; }
    }
}
