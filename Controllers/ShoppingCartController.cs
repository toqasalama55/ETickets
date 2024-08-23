using ETickets.Data;
using ETickets.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        ApplicationDBContext context = new ApplicationDBContext();
        public ShoppingCartController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Index(int MoviesId)
        {
            var userId = userManager.GetUserId(User);
            if(MoviesId != 0)
            {
                ShoppingCart cart = new ()
                  {
                    MoviesId = MoviesId, 
                    ApplicationUserId = userId,
                    Count = 1
                };
                context.ShoppingCart.Add(cart);
                context.SaveChanges();
                //return RedirectToAction("Index", "Home");

            }

            var result = context.ShoppingCart.Include(e=>e.Movies).Where(e => e.ApplicationUserId == userId).ToList();
            return View(result);
        }

        public IActionResult Increment (int Id)
        {
            var result = context.ShoppingCart.Include(e => e.Movies).Where(e => e.Id == Id).FirstOrDefault();
            result.Count++;
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Decrement(int Id)
        {

            var result = context.ShoppingCart.Include(e => e.Movies).Where(e => e.Id == Id).FirstOrDefault();
            if (result.Count == 1)
            {
                context.ShoppingCart.Remove(result);
            }
            else
            result.Count--;

            context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Delete (int Id) 
        {
            var result = context.ShoppingCart.Include(e => e.Movies).Where(e => e.Id == Id).FirstOrDefault();
            context.ShoppingCart.Remove(result);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
