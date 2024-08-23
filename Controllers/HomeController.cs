using ETickets.Data;
using ETickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ETickets.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDBContext context = new ApplicationDBContext();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var res =  context.Movies.Include(e=>e.Cinemas).Include(e=>e.Categories).ToList();
            return View(res);
        }

        public IActionResult Details(int MoviesId)
        {
            
            var res = context.Movies.Find(MoviesId);
            var res2 = context.Movies.Include(e => e.Categories).ToList();
             ViewData["ViewCounter"]= res.ViewCounter++;
            context.SaveChanges();

            // var actor = context.Movies.Include(e => e.Actors).ToList();
            //var movie = context.Movies
            //               .Include(m => m.ActorsMovies)
            //                   .ThenInclude(am => am.Actors)
            //               .FirstOrDefault(m => m.MoviesId == MoviesId);

            return View(res);

        }
        //public IActionResult Details(int id)
        //{
        //    var movie = context.Movies.Include(e => e.Cinemas).Include(e => e.Categories)
        //        .First(e => e.MoviesId == id);

        //    var actorsIds = context.ActorsMovies
        //        .Where(e => e.MoviesId == id)
        //        .Select(e => e.ActorsId)
        //        .ToList();

        //    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
        //    foreach (var item in actorsIds)
        //    {
        //        var actor = context.Actors.Find(item);
        //        if (actor != null)
        //        {
        //            string actorName = $"{actor.FirstName} {actor.LastName}";
        //            keyValuePairs.Add(actorName, actor.ProfilePicture);
        //        }
        //    }

        //    ViewData["actors"] = keyValuePairs;

        //    return View(movie);
        //}
        [HttpGet]
        public IActionResult Search (string Name)
        {
         var res = context.Movies.Include(e => e.Categories).Include(e => e.Cinemas).Where(e => e.Name.Contains(Name)).ToList();
            if (res.Count==0)
            {
                return View("NotFound");
            }
            else
            {
                return View("Index", res);
            }
        }

        public IActionResult ShowCategory(int CategoriesId)
        {
            var res = context.Movies.Include(e => e.Categories).Include(e => e.Cinemas).Where(e=>e.Categories.CategoriesId== CategoriesId).ToList();
           return View("Index", res);
        }

        public IActionResult NotFound()
        {
            return View();
        }

        public IActionResult Edit(int MoviesId)
        {
            var result = context.Movies.Find(MoviesId);

            //compo cinemas
            var result3 = context.Cinemas.Select(e => new SelectListItem
            {
                Value = e.CinemasId.ToString(),
                Text = e.Name
            }).ToList();

            ViewData["ListOfCinemas"] = result3;

            // compo Category
            var result2 = context.Categories.Select(e => new SelectListItem
            {
                Value = e.CategoriesId.ToString(),
                Text = e.Name
            }).ToList();

            ViewData["ListOfCategoy"] = result2;

            return View(result);
                //: RedirectToAction("NotFound");
        }
        [HttpPost]
        public IActionResult Edit(Movies movies)
        {
            var res= context.Movies.Update(movies);
            context.SaveChanges();

            return RedirectToAction("Index");
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
