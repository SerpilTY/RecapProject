﻿using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;


namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();

        IDataResult<Rental> GetById(int RentalId);

        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
    }
}
