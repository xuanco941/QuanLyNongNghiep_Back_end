using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyNongNghiepAPI.Models;
using QuanLyNongNghiepAPI.Services;
using QuanLyNongNghiepAPI.Services.User;

namespace QuanLyNongNghiepAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController
    {

        private readonly ILogger<AuthController> _logger;
        private readonly IUserService _userService;

        public AuthController(ILogger<AuthController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }



        //[HttpGet("GetABC")]
        //public IActionResult GetABC()
        //{
        //    return new JsonResult(new string[] { "abc", "bcf", "123" });
        //}

        [HttpGet]
        public async Task<ActionResult<List<Models.User>?>> GetAllUser()
        {
            return await _userService.GetAllUserAsync();
        }


    }
}
