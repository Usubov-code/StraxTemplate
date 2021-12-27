using Microsoft.AspNetCore.Mvc;
using StraxTemplate.Data;
using StraxTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraxTemplate.Areas.admin.Controllers
{
    [Area("admin")]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            return View(_context.Users.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(User model)
        {
            if(ModelState.IsValid)
            {
                _context.Users.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {

            return View(_context.Users.Find(Id));
        }

        [HttpPost]
        public IActionResult Update(User model)
        {
            if(ModelState.IsValid)
            {
                _context.Users.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }

        }

        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id==null)
            {
                return NotFound();
            }

            User user = _context.Users.Find(Id);
            if (user==null)
            {
                return NotFound();
            }
            _context.Users.Remove(user);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

      
       
    }
}
