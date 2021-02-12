using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarsContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (CarsContext context =new CarsContext())
            {
                var result = from c in context.Cars // arabalar ile
                             join b in context.Brands // Markaları join et
                             on c.CarId equals b.BrandId // 
                             join cl in context.Colors
                             on c.ColorId equals cl.ColorId
                             select new CarDetailsDto { CarId= c.CarId, BrandName=b.BrandName, DailyPrice= c.DailyPrice ,ColorName= cl.ColorName,   Description=c.Description};
                return result.ToList();
            }
        }
    }
}
