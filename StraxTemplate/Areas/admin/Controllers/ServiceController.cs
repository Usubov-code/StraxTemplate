using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StraxTemplate.Data;
using StraxTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraxTemplate.Areas.admin.Controllers
{
    [Area("admin")]
    public class ServiceController : Controller
    {
        private readonly AppDbContext _context;

        public ServiceController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            return View(_context.Services.Include(e=>e.User).Include(a=>a.Category).Include(d=>d.DesingType).ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {


            return View();
        }
        [HttpPost]
        public IActionResult Create(Service model)
        {
           if(ModelState.IsValid)
            {
                _context.Services.Add(model);
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


            return View(_context.Services.Find(Id));
        }


        [HttpPost]
        public IActionResult Update(Service model)
        {
            if(ModelState.IsValid)
            {
                _context.Services.Update(model);
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

            Service service = _context.Services.Find(Id);
            if(service==null)
            {
                return NotFound();
            }

            _context.Services.Remove(service);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
