using BookStoreApp.Data;
using BookStoreApp.Data.Classes;
using BookStoreApp.Data.DTO;
using BookStoreApp.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Security.Cryptography;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthController(IConfiguration configuration, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            var user = await _context.Users.FirstOrDefaultAsync(s => s.RefreshToken == refreshToken);

            if (user == null)
            {
                return Unauthorized("Invalid Refresh Token.");
            }
            else if (user.TokenExpires < DateTime.Now)
            {
                return Unauthorized("Token expired.");
            }

            string token = CreateToken(user);
            var newRefreshToken = GenerateRefreshToken();
            SetRefreshToken(newRefreshToken, user);
            await _context.SaveChangesAsync();

            return Ok(
                new
                {
                    Token = token
                });
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserDTO userDTO)
        {
            CreatePasswordHash(userDTO.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
                UserName = userDTO.UserName,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = userDTO.Role
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return Ok("Registration completed successfully!");
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserShortDTO userDTO) 
        {
            if (userDTO == null)
            {
                return BadRequest("User not found!");
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userDTO.UserName);

            if (user == null)
            {
                return BadRequest("Wrong username");
            }

            if (!VerifyPasswordHash(userDTO.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong Password");
            }

            string token = CreateToken(user);

            var refreshToken = GenerateRefreshToken();

            SetRefreshToken(refreshToken, user);
            await _context.SaveChangesAsync();

            return Ok(
                new
                {
                    Token = token
                });
        }

        [HttpGet("users"), Authorize]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return Ok(await _context.Users.ToListAsync());
        }

        private RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };

            return refreshToken;
        }

        private void SetRefreshToken(RefreshToken newRefreshToken, User user)
        {
            var cookieOption = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires,
            };

            Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOption);

            user.RefreshToken = newRefreshToken.Token;
            user.TokenCreated = newRefreshToken.Created;
            user.TokenExpires = newRefreshToken.Expires;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            // принимает в себя строку и на выходе получаем Hash and Salt
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }

        }

        private string CreateToken(User user) 
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("Role", user.Role),
                new Claim("Name", $"{user.FirstName} {user.LastName}"),
                new Claim("Expires", user.TokenExpires.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,                        
                expires: DateTime.Now.AddDays(1),       
                signingCredentials: creds);      


            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
