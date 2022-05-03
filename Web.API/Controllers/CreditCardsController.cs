using Business.Abstract;
using Entities.Dtos.CreditCard;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {
        ICreditCardService _creditCardService;

        public CreditCardsController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }
        [HttpPost("add-credit-card")]
        public IActionResult AddCreditCard(CreditCardForAddDTO creditCard)
        {
            var result = _creditCardService.AddCreditCard(creditCard);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpGet("get-credit-cards")]
        public IActionResult GetCreditCards()
        {
            var result = _creditCardService.GetAllCreditCards();
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpGet("get-credit-card-by-card-number")]
        public IActionResult GetCreditCardByCardNumber(string cardNumber)
        {
            var result = _creditCardService.GetCreditCardByCardNumber(cardNumber);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpDelete("delete-credit-card")]
        public IActionResult DeleteCreditCard(int cardId)
        {
            var result = _creditCardService.DeleteCreditCard(cardId);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpPut("update-credit-card")]
        public IActionResult UpdateCreditCardTitle(CreditCardForUpdateDTO creditCard)
        {
            var result = _creditCardService.UpdateCreditCardTitle(creditCard);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
