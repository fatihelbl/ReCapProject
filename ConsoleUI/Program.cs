using Business.Concrete;
using Business.Constans;
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
            //CarBrandDailyPriceTest();
            //CarTest();
            //BrandTest();
            //ColorGetAllTest();
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result= rentalManager.GetRentDetails();
            if (result.Success == true)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine(rental.CompanyName);

                }
            }


            //CarAddTest();
            //CarGetAllTest();

        }

        private static void CarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car1 = new Car();
            car1.CarId = 6;
            car1.BrandId = 3;
            car1.ColorId = 1;
            car1.ModelYear = 2018;
            car1.DailyPrice = 180;
            car1.Description = "Dizel";
            carManager.Add(car1);
            Console.WriteLine(Messages.CarAdded);
        }

        private static void ColorGetAllTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();

            if (result.Success == true)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.ColorId + ". Renk " + color.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarBrandDailyPriceTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarId + " numaralı aracın markası: " + car.BrandName + ", Yakıt türü: " + car.Description + ", Rengi : " + car.ColorName + ", Fiyati= " + car.DailyPrice);
                    

                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var result = brandManager.GetAll();

            if (result.Success == true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName);

                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetByDailyPrice(80,150);

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarId);

                }
            }

            else
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void CarGetAllTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarId + ". Araç, Markası: " + car.BrandName + ", Fiyati: " + car.DailyPrice);

                }
            }

            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
