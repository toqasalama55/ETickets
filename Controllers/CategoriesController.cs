using ETickets.Data;
using ETickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace ETickets.Controllers
{
    public class CategoriesController :Controller
    {
        ApplicationDBContext context = new ApplicationDBContext();

        public IActionResult Category()
        {
            var res=context.Categories.ToList();
            return View(res);
        }

        public IActionResult Details(int CategoriesId)
        {
            var res=context.Categories.Include(e=>e.Movies).ThenInclude(c=>c.Cinemas).Where(e=>e.CategoriesId== CategoriesId).ToList();
            return View(res);
            //  return RedirectToAction("ShowCategory","Home");

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categories category)
        {
            if (ModelState.IsValid)
            {
              var res= context.Categories.Add(category);
                context.SaveChanges();
                return RedirectToAction("Category");
            }
            return View(category);
       


        }
    }
}
