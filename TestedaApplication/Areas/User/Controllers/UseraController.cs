using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestedaApplication.Data;
using TestedaApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace TestedaApplication.Areas.Usera.Controllers
{
    [Area("User")]
    public class UseraController : Controller
    {
        private readonly AppDbContext db;
        private readonly UserManager<IdentityUser> userManager;
        private string UserID_;
        private readonly DataManager dataManager;
        public UseraController(AppDbContext context, UserManager<IdentityUser> _userManager)
        {
            db = context;
            userManager = _userManager;
            dataManager = new DataManager(db);
        }

        public IActionResult ListUs()
        {
            return View(db.Cars.ToList());
        }

        public IActionResult CarDeskUs(int id)
        {
            return View(db.Cars.FirstOrDefault(x => x.Id == id));
        }

        public IActionResult ToFavouriteUs(int idFav) //Плохой метод - переделать
        {
            UserID_ = userManager.GetUserId(User);
            UserFavs favCar = new UserFavs()
            {
                UserId = UserID_,
                CarId = idFav,
            };
            db.Favourites.Add(favCar);
            db.SaveChanges();
            return View( );
        }

        public IActionResult FavouritesUs()
        {
            UserID_ = userManager.GetUserId(User);
            return View(dataManager.GetCarsFromFavourites(UserID_));
        }

        public IActionResult FavouriteDeleteUs(int favCarId) //Плохой метод - переделать
        {
            UserID_ = userManager.GetUserId(User);

            db.Favourites.Remove(db.Favourites.FirstOrDefault( x => x.CarId == favCarId && x.UserId == UserID_) ); //Небезопасно но работает
            db.SaveChanges();
            return RedirectToAction("FavouritesUs", "Usera");
        }

        public IActionResult UserProfile()
        {
            UserID_ = userManager.GetUserId(User);
            return View();
        }
    }
}