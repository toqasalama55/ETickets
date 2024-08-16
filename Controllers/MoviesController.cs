using ETickets.Data;
using ETickets.Data.Enum;
using ETickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;

namespace ETickets.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDBContext context = new ApplicationDBContext();

        //public IActionResult Movies()
        //{
        //    var res=context.Movies.ToList();
        //    return View(res);
        //}

       

        [HttpGet]
        public IActionResult Create()
        {
            //compo cinemas
            var result = context.Cinemas.Select(e => new SelectListItem
            {
                Value = e.CinemasId.ToString(),
                Text = e.Name
            }).ToList();

            ViewData["ListOfCinemas"] = result;

            // compo Category
            var result2 = context.Categories.Select(e => new SelectListItem
            {
                Value = e.CategoriesId.ToString(),
                Text = e.Name
            }).ToList();

            ViewData["ListOfCategoy"] = result2;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movies movies)
        {
            if (ModelState.IsValid)
            {
                if (DateTime.Now >= movies.StartDate && DateTime.Now <= movies.EndDate)
                 movies.MovieStatus = MovieStatus.Available;
                else if (DateTime.Now < movies.StartDate)
                    movies.MovieStatus = MovieStatus.Upcoming;
                else
                    movies.MovieStatus = MovieStatus.Expired;

                var res = context.Movies.Add(movies);
                context.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            return View(movies);



        }
    }
}
