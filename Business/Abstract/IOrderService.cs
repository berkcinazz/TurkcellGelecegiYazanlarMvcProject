using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IResult AddOrder(OrderForAddDto order);
        IResult UpdateOrder(OrderForUpdateDto order);
        IDataResult<Order> GetOrderByOrderCode(string orderCode);
        IResult CancelOrder(string orderCode);
    }
}
