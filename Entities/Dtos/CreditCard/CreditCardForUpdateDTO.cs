using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.CreditCard
{
    public class CreditCardForUpdateDTO : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
