using FoodRepository.Models;
using FoodRepository.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodRepository.Controllers
{
    public class UserController : Controller
    {
        // GET: UserController
        private IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            var res = _userRepository.GetUserItems();
            return View(res);
        }

        // GET: UserController/Details/5
        public IActionResult Details(int id)
        {
            var res = _userRepository.GetDetails(id);
            return View(res);
        }

        // GET: UserController/Create
        public IActionResult Create(int? id)
        {
            var model = _userRepository.createview(id);
            model.itemname = _userRepository.SelectedItems();
            ViewBag.username = _userRepository.SelectedNames();
            return View(model);
           
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int? id, Model obj)
        {
            var selecteditem = obj.itemname.Where(x => x.Selected).Select(y => y.Value).ToList();
            int uid = obj.Username;
            if (ModelState.IsValid)
            {
                _userRepository.Add(id, selecteditem, uid);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: UserController/Edit/5
       

        // GET: UserController/Delete/5
        public IActionResult Delete(int id)
        {
            _userRepository.Delete(id);
            return RedirectToAction("Index");
        }

        // POST: UserController/Delete/5
        
    }
}
