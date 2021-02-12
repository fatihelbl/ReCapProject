using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarBrandDailyPriceTest();
            //CarTest();
            //BrandTest();


            //Car car1 = new Car();
            //car1.CarId = 5;
            //car1.BrandId = 2;
            //car1.ColorId = 1;
            //car1.ModelYear = 2002;
            //car1.DailyPrice = 100;
            //car1.Description = "LPG";



        }

        private static void CarBrandDailyPriceTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarId + " numaralı aracın markası: " + car.BrandName + ", Yakıt türü: "+ car.Description + ", Rengi : " + car.ColorName + ", Fiyati= " +car.DailyPrice);

            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);

            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetByDailyPrice(190, 260))
            {
                Console.WriteLine(car.CarId);

            }
        }
    }
}
