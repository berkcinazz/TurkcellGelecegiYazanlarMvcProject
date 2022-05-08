using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public partial class Order : IEntity
    {
        public int Id { get; set; }
        public Guid Code { get; set; }
        public int UserId { get; set; }
        public string Address { get; set; }
        public DateTime OrderDate { get; set; }
        public short PaymentType { get; set; }
        public short Status { get; set; }
        public float Total { get; set; }
        public DateTime LastStatusChange { get; set; }

    }
}
