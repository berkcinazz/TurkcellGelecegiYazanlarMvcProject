using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Publisher;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IPublisherService
    {
        IResult AddPublisher(PublisherForAddDto publisher);
        IResult DeletePublisher(int publisherId);
        IResult UpdatePublisher(Publisher publisher);
        IDataResult<List<Publisher>> GetAllPublishers();
        IDataResult<Publisher> GetPublisherById(int publisherId);
    }
}
