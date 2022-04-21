using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public partial class CreditCard : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string OwnersName { get; set; }
        public string Number { get; set; }
        public string ExpireDate { get; set; }
        public string Cvv { get; set; }
        public int UserId { get; set; }
        public string CreditCardType { get; set; }
    }
}
