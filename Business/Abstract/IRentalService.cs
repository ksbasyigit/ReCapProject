﻿using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();

        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);

        DataResult<List<RentalDetailDto>> GetRentalDetails();
    }
}