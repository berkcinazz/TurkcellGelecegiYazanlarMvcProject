﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Category
{
    public class CategoryForAddDto:IDto
    {
        public string Name { get; set; }
    }
}
