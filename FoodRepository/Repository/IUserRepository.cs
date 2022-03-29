using FoodRepository.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodRepository.Repository
{
    public interface IUserRepository
    {
        List<SelectListItem> SelectedNames();
        List<SelectListItem> SelectedItems();
        IEnumerable<UserItem> GetUserItems();
        Model createview(int? id);
        IEnumerable<UserItem> GetDetails(int id);
        void Delete(int id);
        void Add(int? id, List<string> m, int uid);
    }
}
