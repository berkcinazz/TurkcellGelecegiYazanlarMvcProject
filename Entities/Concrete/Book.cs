using Core.Entities.Abstract;
using System;

namespace Entities.Concrete
{
    public class Book:IEntity
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public DateTime? PublishDate { get; set; }
        public float Price { get; set; }
    }
}
