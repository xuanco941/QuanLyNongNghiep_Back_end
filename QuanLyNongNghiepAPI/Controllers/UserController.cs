using QuanLyNongNghiepAPI.Services.Authentication;

namespace QuanLyNongNghiepAPI.Controllers
{

    public class UserController
    {
        private readonly ILogger<AuthController> _logger;


        public UserController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }
    }
}
