using ETickets.Data;
using ETickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace ETickets.Controllers
{
    public class CinemasController : Controller
    {
        ApplicationDBContext context = new ApplicationDBContext();

        public IActionResult Cinema()
        {
            var res=context.Cinemas.ToList();
            return View(res);
        }

        public IActionResult Details(int CinemasId)
        {
            var res=context.Cinemas.Include(e=>e.Movies).Where(e=>e.CinemasId == CinemasId).ToList();
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
        public IActionResult Create(Cinemas cinemas)
        {
            if (ModelState.IsValid)
            {
                var res = context.Cinemas.Add(cinemas);
                context.SaveChanges();
                return RedirectToAction("Cinema");
            }
            return View(cinemas);



        }
    }
}
