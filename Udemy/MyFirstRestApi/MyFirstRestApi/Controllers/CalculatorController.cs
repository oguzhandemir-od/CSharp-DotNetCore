using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("Calculate")]
        public IActionResult Calculate(decimal firstNumber, decimal secondNumber, string actionType)
        {
            decimal result;
            switch (actionType)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    result = firstNumber / secondNumber;
                    break;
                default:
                    result = 0;
                    return NotFound(result);
            }

            return Ok(result);
        }
    }
}
