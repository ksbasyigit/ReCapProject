﻿using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class CarImages:IEntity
    {
        public int id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
