using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Order
{
    public class OrderForUpdateDto
    {
        public Guid Code { get; set; }
        public string Address { get; set; }
        public short Status { get; set; }
        public DateTime LastStatusChange { get; set; }
    }
}
