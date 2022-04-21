using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAllBrands();
        IResult AddBrand(BrandForAddDTO brand);
        IResult UpdateBrand(BrandForUpdateDTO brand);
        IResult DeleteBrand(int id);
    }
}
