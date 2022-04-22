using Business.Abstract;
using Business.Constants;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public IResult AddBrand(BrandForAddDTO brand)
        {
            Brand brandToAdd = new Brand()
            {
                Name = brand.Name,
                Approved = false
            };
            _brandDal.Add(brandToAdd);
            return new SuccessResult(Messages.BrandAdded);
        }
        public IResult DeleteBrand(int id)
        {
            var brandToDelete = _brandDal.Get(b => b.Id == id);
            if (brandToDelete == null) return new ErrorResult(Messages.BrandNotFound);
            _brandDal.Delete(brandToDelete);
            return new SuccessResult(Messages.BrandDeleted);
        }
        public IDataResult<List<Brand>> GetAllBrands()
        {
            var result = _brandDal.GetAll();
            return new SuccessDataResult<List<Brand>>(result);
        }

        public IDataResult<Brand> GetBrandById(int id)
        {
            var brand = _brandDal.Get(b => b.Id == id);
            if (brand == null) return new ErrorDataResult<Brand>(Messages.BrandNotFound);
            return new SuccessDataResult<Brand>(brand);
        }

        public IResult UpdateBrand(BrandForUpdateDTO brand)
        {
            Brand brandToUpdate = _brandDal.Get(b => b.Id == brand.Id);
            if (brandToUpdate == null) return new ErrorResult(Messages.BrandNotFound);
            brandToUpdate.Name = brand.Name;
            _brandDal.Update(brandToUpdate);
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
