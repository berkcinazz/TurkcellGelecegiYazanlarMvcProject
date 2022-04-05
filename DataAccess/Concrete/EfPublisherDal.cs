﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfPublisherDal : EFRepositoryBase<Publisher, EFCoreContext>,IPublisherDal
    {
    }
}
