using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyNongNghiepAPI.Services;

namespace QuanLyNongNghiepAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController
    {

        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetABC")]
        public IActionResult GetABC()
        {
            return new JsonResult(new string[] { "abc", "bcf", "123" });
        }
        //[HttpGet(Name = "GetCBA")]
        //public IActionResult GetCBA()
        //{
        //    return new JsonResult(new string[] { "cba", "bcf", "123" });
        //}


    }
}
