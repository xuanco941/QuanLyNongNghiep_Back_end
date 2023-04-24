using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using QuanLyNongNghiepAPI.DataTransferObject.UserDTOs;
using QuanLyNongNghiepAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QuanLyNongNghiepAPI.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IConfiguration _config;

        public AuthenticationService(DatabaseContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;
        }
        public async Task<Models.User?> AuthenticateUserAsync(LoginDTO login)
        {
            try
            {
                Models.User? user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Username == login.Username && u.Password == login.Password);
                return user;
            }
            catch
            {
                throw;
            }
        }

        public string GenerateTokenForUser(Models.User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new List<Claim>
                {
                new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()), //Id của user
                new Claim(ClaimTypes.Email, user.Email), // thêm claim email
                new Claim(ClaimTypes.Role, user.Role), // thêm claim role
                 }),
                Expires = DateTime.Now.AddDays(double.Parse(_config["Jwt:ExpireDays"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }



    }
}
