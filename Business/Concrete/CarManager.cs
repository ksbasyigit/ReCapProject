﻿using Business.Abstract;using DataAccess.Abstract;using Entities.Concrete;using System;using System.Collections.Generic;using Entities.DTOs;
using Core.Utilities.Results;
using Business.Constants;
using System.Linq;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;

namespace Business.Concrete{

    public class CarManager : ICarService    {        ICarDal _carDal;        public CarManager(ICarDal carDal)        {            _carDal = carDal;        }        [ValidationAspect(typeof(CarValidator))]        public IResult Add(Car car)        {            if (car.Description.Length < 2)
            {
                return new ErrorResult(Messages.CarDescInvalid);//magic string ten kurtulmak için Business.Constants altında Message class oluşturduk.
            }            _carDal.Add(car);            return new SuccessResult(Messages.CarRecorded);            //Console.WriteLine(Messages.CarRecorded);        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
            //Console.WriteLine("Car deleted.");
        }

        public IDataResult<List<Car>> GetAll()        {            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);        }        public IDataResult<List<Car>> GetCarsByBrandId(int id)        {            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=>p.BrandId == id ));        }        public IDataResult<List<Car>> GetCarsByColorId(int id)        {            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));        }

        public DataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }}