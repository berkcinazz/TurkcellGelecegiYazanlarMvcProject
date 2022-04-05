using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Publisher;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class PublisherManager : IPublisherService
    {
        IPublisherDal _publisherDal;
        public PublisherManager(IPublisherDal publisherDal)
        {
            _publisherDal = publisherDal;
        }
        public IResult AddPublisher(PublisherForAddDto publisher)
        {
            var addToPublisher = new Publisher()
            {
                Name = publisher.Name,
                Address = publisher.Address,
            };
            _publisherDal.Add(addToPublisher);
            return new SuccessResult("Publisher Added");
        }
        public IResult DeletePublisher(int publisherId)
        {
            var result = _publisherDal.Get(i => i.Id == publisherId);
            if (result == null) return new ErrorResult("Publisher Not Found");
            _publisherDal.Delete(result);
            return new SuccessResult("Publisher Has Been Deleted");
        }
        public IDataResult<List<Publisher>> GetAllPublishers()
        {
            var result = _publisherDal.GetAll();
            return new SuccessDataResult<List<Publisher>>(result);
        }
        public IDataResult<Publisher> GetPublisherById(int publisherId)
        {
            var result = _publisherDal.Get(i=>i.Id == publisherId);
            if (result == null) return new ErrorDataResult<Publisher>("Publisher Not Found");
            return new SuccessDataResult<Publisher>(result);
        }
        public IResult UpdatePublisher(Publisher publisher)
        {
            var result = _publisherDal.Get(i => i.Id == publisher.Id);
            if (result == null) return new ErrorResult("Publisher Not Found");
            result.Name = publisher.Name;
            result.Address = publisher.Address;
            _publisherDal.Update(result);
            return new SuccessResult("Publisher Updated");
        }
    }
}
