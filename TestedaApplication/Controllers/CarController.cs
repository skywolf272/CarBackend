using System;
using System.Collections.Generic;
using System.Linq;
using TestedaApplication.Data.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TestedaApplication.Data.Controllers
{
    public class CarController : Controller
    {
        private AppDbContext db;
        public CarController(AppDbContext context)
        {
            db = context;
        }

        public IActionResult CarDesc(int id)
        {
            Car car = db.Cars.FirstOrDefault(a => a.Id == id);
            return View( car );
        }
        
        public IActionResult List()
        {
            
            return View( db.Cars.ToList() );
        }
    }
}
