using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestedaApplication.Data;
using TestedaApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace TestedaApplication.Areas.Usera.Controllers
{
    [Area("User")]
    public class UseraController : Controller
    {
        private readonly AppDbContext db;
        private readonly UserManager<IdentityUser> userManager;
        private string UserID_;
        private readonly DataManager dataManager;
        private readonly ILogger<UseraController> _log;
        public UseraController(AppDbContext context, UserManager<IdentityUser> _userManager, ILogger<UseraController> logger)
        {
            db = context;
            userManager = _userManager;
            dataManager = new DataManager(db);
            _log = logger;
            _log.LogInformation("UserControlled was administed.");
        }

        public IActionResult ListUs()
        {
            return View(db.Cars.ToList());
        }

        public IActionResult CarDeskUs(int id)
        {
            return View(db.Cars.FirstOrDefault(x => x.Id == id));
        }

        public IActionResult ToFavouriteUs(int idFav)
        {
            UserID_ = userManager.GetUserId(User);
            _log.LogInformation("FavouriteId = " + idFav.ToString() + "; UserID = " + UserID_);
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
    }
}