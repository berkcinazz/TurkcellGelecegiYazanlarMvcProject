using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Brand
{
    public class BrandForAddDTO : IDto
    {
        public string Name { get; set; }
        public string Avatar { get; set; }
    }
}
