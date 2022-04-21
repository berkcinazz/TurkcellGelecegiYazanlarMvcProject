using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.CreditCard
{
    public class CreditCardForAddDTO : IDto
    {
        public string Title { get; set; }
        public string OwnersName { get; set; }
        public string Number { get; set; }
        public string ExpireDate { get; set; }
        public string CVV { get; set; }
    }
}
