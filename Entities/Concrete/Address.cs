using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public partial class Address : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Quarter { get; set; }
        public string AddressString { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gsm { get; set; }
        public int UserId { get; set; }
    }
}
