using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PaySky.IRepository;
using PaySky.Models;

namespace PaySky.Controllers
{
    [Route("api/")]

    public class LoginController : Controller
    {
       
            private readonly IConfiguration _config;
        private readonly IUserRepository _userRepository;

        public LoginController(IConfiguration config, IUserRepository userRepository)
        {
            _config = config;
            _userRepository = userRepository;
        }

            [HttpPost]
            [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserModel login)
            {

            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
                IActionResult response = Unauthorized();
                UserModel user = await _userRepository.GetUser(login);
                if (user != null)
                {
                    var tokenString = GenerateJWT(user);
                    response = Ok(new
                    {
                        token = tokenString,
                        userDetails = user,
                    });
                }
                else
            {
                response = Ok(new { Message = "Invalid User" });
            }
            return response;
            }

            string GenerateJWT(UserModel userInfo)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
          
            var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

                var token = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                    audience: _config["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credentials
                );
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        }
    }
