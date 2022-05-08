using Business.Abstract;
using Business.BusinessAspects.SecuredOperation;
using Business.Constants;
using Core.Extensions;
using Core.Utilities.Helpers;
using Core.Utilities.IoC;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;
        IHttpContextAccessor _httpContextAccessor;

        public OrderManager(IOrderDal orderDal, IHttpContextAccessor httpContextAccessor)
        {
            _orderDal = orderDal;
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        public IResult AddOrder(OrderForAddDto order)
        {
            var userId = _httpContextAccessor.HttpContext.User.GetAuthenticatedUserId();

            Order newOrder = new Order()
            {
                OrderDate = DateTime.Now,
                Code = OrderNumberHelper.GenerateOrderNumber(),
                Address = order.Adress,
                UserId = userId,
                Status = 1,
                PaymentType = order.PaymentType,
                LastStatusChange = DateTime.Now,
                Total = order.Total,
            };
            _orderDal.Add(newOrder);
            return new SuccessResult(Messages.OrderAdded);
        }
        [SecuredOperation("")]
        public IResult CancelOrder(string orderCode)
        {
            var userId = _httpContextAccessor.HttpContext.User.GetAuthenticatedUserId();
            var result = _orderDal.Get(i=>i.Code.ToString() == orderCode && i.UserId == userId);
            if (result == null) return new ErrorResult(Messages.OrderNotFound);
            result.Status = 0;
            result.LastStatusChange = DateTime.Now;
            _orderDal.Update(result);
            return new SuccessResult(Messages.OrderCanceled);
        }

        public IDataResult<Order> GetOrderByOrderCode(string orderCode)
        {
            var userId = _httpContextAccessor.HttpContext.User.GetAuthenticatedUserId();
            var result = _orderDal.Get(i => i.Code.ToString() == orderCode && i.UserId == userId);
            if (result == null) return new ErrorDataResult<Order>(Messages.OrderNotFound);
            return new SuccessDataResult<Order>(result);
        }

        public IResult UpdateOrder(OrderForUpdateDto order)
        {
            var userId = _httpContextAccessor.HttpContext.User.GetAuthenticatedUserId();
            var result = _orderDal.Get(i => i.Code.ToString() == order.Code.ToString() && i.UserId == userId);
            if (result == null) return new ErrorDataResult<Order>(Messages.OrderNotFound);
            result.Status = order.Status;
            result.Address = order.Address;
            result.LastStatusChange = DateTime.Now;
            _orderDal.Update(result);
            return new SuccessResult(Messages.OrderUpdated);
        }
    }
}
