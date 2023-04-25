﻿using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using QuanLyNongNghiepAPI.DataTransferObject.UserDTOs;
using QuanLyNongNghiepAPI.Models;
using QuanLyNongNghiepAPI.Services.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QuanLyNongNghiepAPI.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IConfiguration _config;
        private readonly IUserService _userService;

        public AuthenticationService(DatabaseContext dbContext, IConfiguration config, IUserService userService)
        {
            _dbContext = dbContext;
            _config = config;
            _userService = userService;
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



        public async Task<Models.User?> RegisterUserAsync(RegisterDTO register)
        {
            Random rand = new Random();
            string password = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                password = password + rand.Next(0, 10);
            }
            Models.User user = new Models.User()
            {
                FullName = register.FullName,
                Username = register.Username,
                Address = register.Address,
                Email = register.Email,
                PhoneNumber = register.PhoneNumber,
                Password = password
            };

            try
            {
                await _dbContext.AddAsync(user);
                int num = await _dbContext.SaveChangesAsync();
                if (num > 0)
                {
                    return user;
                }
                else
                {
                    return null;
                }

            }
            catch
            {
                throw;
            }
        }



        public async Task<Models.User?> ForgotPasswordAsync(ForgotPasswordDTO forgotPassword)
        {
            Random rand = new Random();
            string password = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                password = password + rand.Next(0, 10);
            }

            try
            {
                Models.User? user = _dbContext.Users.FirstOrDefault(a => a.Username == forgotPassword.Username);
                if (user != null)
                {
                    user.Password = password;
                }
                int num = await _dbContext.SaveChangesAsync();
                if (num > 0)
                {
                    return user;
                }
                else
                {
                    return null;
                }

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> ChangePasswordAsync(ChangePasswordDTO changePassword)
        {
            try
            {
                int? userId = _userService.GetUserIDContext();
                if (userId != null)
                {
                    Models.User? user = await _dbContext.Users.FirstOrDefaultAsync(a => a.UserID == userId);
                    if (user != null)
                    {
                        user.Password = changePassword.NewPassword;
                    }
                    int num = await _dbContext.SaveChangesAsync();
                    if (num > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;
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
