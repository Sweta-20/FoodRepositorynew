using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodRepository.Models
{
    public class Model
    {
        public int Username { get; set; }
        public IList<SelectListItem> itemname { get; set; }
        public List<int> itemids { get; set; }
    }
}
