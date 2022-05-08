using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Order
{
    public class OrderForAddDto:IDto
    {
        public string Adress { get; set; }
        public short PaymentType { get; set; }
        public float Total { get; set; }
    }
}
