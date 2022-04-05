using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Book
{
    public class BookForAddDto:IDto
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public DateTime? PublishDate { get; set; }
        public double Price { get; set; }
    }
}
