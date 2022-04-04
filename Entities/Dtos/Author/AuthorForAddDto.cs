using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Author
{
    public class AuthorForAddDto:IDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
