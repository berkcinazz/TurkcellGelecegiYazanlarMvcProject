using Business.Abstract;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.JWT;
using Core.Utilities.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessAspects.Authentication
{
    public class AuthenticationAttribute : MethodInterception
    {
        //Not working should be fixed
        private IHttpContextAccessor _httpContextAccessor;
        public AuthenticationAttribute()
        {
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var isAuthenticated = _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
            if (!isAuthenticated) throw new UnauthorizedException();
        }
    }
}
