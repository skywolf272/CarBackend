using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestedaApplication.Data.Models;
using TestedaApplication.Models;
using System.Diagnostics;

namespace TestedaApplication.Data
{
    public class DataManager
    {

        private AppDbContext db;
        public DataManager(AppDbContext context)
        {
            db = context;
        }

        public List<Car> GetCars()
        {
            return db.Cars.ToList();
        }

        public List<Car> GetCarsFromFavourites(string _userID)
        {
            List<UserFavs> Favs = db.Favourites.Where(x => x.UserId == _userID).ToList();
            Favs[0] = Favs[0];
            List<Car> cars = new List<Car>();
            for (int i = 0; i < Favs.Count(); i++)
            {
                cars.Add(db.Cars.FirstOrDefault(x => x.Id == Favs[i].CarId));
            }
            return cars;
        }

        public List<Category> GetCategories()
        {
            return db.Categories.ToList();
        }

        public Car GetCar(int id)
        {
            return db.Cars.FirstOrDefault(x => x.Id == id);
        }

        public void SaveCar(string _Name, string _ShortDescription, string _WholeDescription, string _Image, int _Price, int _Avaliable, string _CategoryName)
        {
            Car car = new Car();
            {
                car.Name = _Name;
                car.ShortDescription = _ShortDescription;
                car.WholeDescription = _WholeDescription;
                car.Image = _Image;
                car.Price = _Price;
                car.Avaliable = _Avaliable;
                car.CategoryID = db.Categories.FirstOrDefault(x => x.Name == _CategoryName).Id;
            };
            db.Cars.Add(car);
            db.SaveChanges();
        }

        public void SaveCar(Car _car)
        {
            db.Cars.Add(_car);
            db.SaveChanges();
        }
    }
}
