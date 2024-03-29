﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    //Id,CarId,ImagePath,Date
    public class CarImage:IEntity
    {
        public CarImage()
        {
            Date = DateTime.Now;
        }

        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
