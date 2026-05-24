using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet("SayHello")]
        public string SayHello()
        {
            string firstMessage = "Hi, this is my first RestFul API";
            return firstMessage;
        }
        [HttpGet("SayHelloAction")]
        public IActionResult SayHelloAction()
        {
            string firstMessage = "Hi, this is my first RestFul API";
            return Ok(firstMessage);
        }
        [HttpGet("SayHelloFirstName")]
        public IActionResult SayHelloFirstName(string firstName)
        {
            string firstMessage = $"Hi {firstName}, this is my first Parameter API";
            return Ok(firstMessage);
        }
        [HttpGet("SayHelloFullName")]
        public IActionResult SayHelloFullName(string firstName,string lastName)
        {
            string firstMessage = $"Hi {firstName} {lastName}, this is my first Parameter API";
            return Ok(firstMessage);
        }
    }
}
