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
    //NuGet
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal

    {
        //IDisposable pattern implementation of C#

        public List<CarDetailDto> GetCarDto(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                                 on c.BrandId equals b.BrandId

                             join col in context.Colors
                                 on c.ColorId equals col.ColorId

                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 ModelName = c.ModelName,
                                 ColorName = col.ColorName,
                                 BrandId = c.BrandId,
                                 ColorId = c.ColorId,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 Description = c.Description,
                                 ImagePath = (from m in context.CarImages 
                                              where m.CarId == c.CarId select m.ImagePath).ToList(),
                             };
                return filter is null ? result.ToList() : result.Where(filter).ToList(); 

            }
        }
    }
}
