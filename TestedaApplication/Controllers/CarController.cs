using System;
using System.Collections.Generic;
using System.Linq;
using TestedaApplication.Data.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TestedaApplication.Data.Controllers
{
    public class CarController : Controller
    {
        private readonly AppDbContext db;
        private readonly ILogger<CarController> _logger;
        public CarController(AppDbContext context, ILogger<CarController> logger)
        {
            db = context;
            _logger = logger;
        }

        public IActionResult CarDesc(int id)
        {
            Car car = db.Cars.FirstOrDefault(a => a.Id == id);
            return View( car );
        }
        
        public IActionResult List()
        {
            
            return View(db.Cars.ToList());
        }

        public IActionResult FindByName(string CarName)
        {
            if (CarName != null)
            {
                foreach (var finded_car in db.Cars.ToList().Where(x => x.Name.Contains(CarName)))
                {
                    if (finded_car.Name.Contains(CarName))
                    {
                        _logger.LogInformation(finded_car.Name);
                    }
                }
                return View(db.Cars.ToList().Where(x => x.Name.Contains(CarName)));
            }
            return RedirectToAction("List", "Car");
        }
    }
}
