using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class PublisherController : Controller
    {
        IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        //public  Task<IActionResult> Index()
        //{
        //    var result = _publisherService.GetAllPublishers().Data;
        //    result.ForEach(i => new { Text = i.Name && Adress = i.Address });
        //    return View(result);
        //}
    }
}
