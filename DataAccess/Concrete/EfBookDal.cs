﻿using Core.DataAccess.EntityFramework;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfBookDal : EFRepositoryBase<Book, EFCoreContext>
    {
    }
}
