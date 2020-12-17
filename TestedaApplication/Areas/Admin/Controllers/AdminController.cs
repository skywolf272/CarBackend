using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using TestedaApplication.Data;
using Microsoft.AspNetCore.Authorization;
using TestedaApplication.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Web;

namespace TestedaApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly AppDbContext db;
        IWebHostEnvironment _appEnvironment; //Принять объект картинки из формы

        private DataManager dataManager;


        public AdminController(AppDbContext context, IWebHostEnvironment appEnvironment)
        {
            db = context;
            _appEnvironment = appEnvironment;

            dataManager = new DataManager(context);
        }

        public IActionResult ListAd()
        {
            return View(db.Cars.ToList());
        }

        public IActionResult CarDescAd(int id)
        {
            return View(db.Cars.FirstOrDefault(x => x.Id == id));
        }

        public IActionResult CreateAutoAd()
        {
            return View(dataManager);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAutoAd(string name, string shortDesc, string wholeDesc, IFormFile img, int price, int avail, string categoryName) //Переписать под объект
        {
            string file_path = "/img/" + img.FileName;
            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + file_path, FileMode.Create))
            {
                await img.CopyToAsync(fileStream);
            }
            dataManager.SaveCar(name, shortDesc, wholeDesc, "/img/" + img.FileName, price, avail, categoryName);
            return RedirectToAction("ListAd", "Admin");
        }

        public IActionResult DeleteCarAd(int id_del)
        {
            Car carToDel = db.Cars.FirstOrDefault(z => z.Id == id_del);
            if(System.IO.File.Exists(_appEnvironment.WebRootPath + carToDel.Image))
            {
                System.IO.File.Delete(_appEnvironment.WebRootPath + carToDel.Image);
                db.Cars.Remove(db.Cars.FirstOrDefault(x => x.Id == id_del));
                db.SaveChanges();
            }
            return RedirectToAction("ListAd", "Admin");
        }
    }
}
