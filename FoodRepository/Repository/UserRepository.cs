using FoodRepository.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodRepository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbcontext;
        public UserRepository(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public void Add(int? id, List<string> selecteditem, int uid)
        {
            var demo = new List<UserItem>();
            foreach (var item in selecteditem)
            {
                demo.Add(new UserItem()
                {
                    uid = uid,
                    Itemid = int.Parse(item)
                });
            }
            if (id != null)
            {
                var result = _dbcontext.userItems.Where(x => x.uid == id);
                _dbcontext.RemoveRange(result);
            }
            _dbcontext.userItems.AddRange(demo);
            _dbcontext.SaveChanges();
        }

        public Model createview(int? id)
        {
            var model = new Model();
            model.Username = (int)id;
            model.itemids = _dbcontext.userItems.Where(x => x.uid == id).GroupBy(x => x.Itemid).Select(x => x.Key).ToList();
            return model;
        }

        public void Delete(int id)
        {
            var result = _dbcontext.userItems.Where(x => x.uid == id);
            _dbcontext.RemoveRange(result);
            _dbcontext.SaveChanges();
        }

        public IEnumerable<UserItem> GetDetails(int id)
        {
            var result = _dbcontext.userItems.Where(x => x.uid == id).Include("Itemname").Include("User").ToList();
            return result;
        }

        public IEnumerable<UserItem> GetUserItems()
        {
            var result = _dbcontext.userItems.Include("Item").Include("User").ToList();
            return result;
        }

        public List<SelectListItem> SelectedItems()
        {
            var itemstore = _dbcontext.itemnames.Select(x => new SelectListItem()
            {
                Text = x.ItemName,
                Value = x.ItemID.ToString()
            }).ToList();
            return itemstore;
        }

        public List<SelectListItem> SelectedNames()
        {
            var username = _dbcontext.Users.Select(x => new SelectListItem()
            {
                Text = x.username,
                Value = x.userid.ToString()
            }).ToList();
            return username;
        }
    }
}
