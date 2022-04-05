using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.Publisher;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }
        [HttpGet("get-all-publishers")]
        public IActionResult GetAllPublishers()
        {
            var result = _publisherService.GetAllPublishers();
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpGet("get-publisher-by-id")]
        public IActionResult GetPublisherById(int PublisherId)
        {
            var result = _publisherService.GetPublisherById(PublisherId);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpPost("add-publisher")]
        public IActionResult AddPublisher(PublisherForAddDto Publisher)
        {
            var result = _publisherService.AddPublisher(Publisher);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpPut("update-publisher")]
        public IActionResult UpdatePublisher(Publisher publisher)
        {
            var result = _publisherService.UpdatePublisher(publisher);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpDelete("delete-publisher")]
        public IActionResult DeletePublisher(int publisherId)
        {
            var result = _publisherService.DeletePublisher(publisherId);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
