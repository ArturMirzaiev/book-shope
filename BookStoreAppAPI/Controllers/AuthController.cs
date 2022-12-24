using BookStoreApp.Data;
using BookStoreApp.Data.Classes;
using BookStoreApp.Data.DTO;
using BookStoreApp.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        /* статический объект, хранящий в себе
                        UserName    string
                        PasswordHash   byte[]
                        PasswordSalt    byte[]
                        RefreshToken    string
                        TokenCreated    DateTime
                        TokenExpires    DateTime
        */

        public IConfiguration _configuration;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthController(IConfiguration configuration, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet, Authorize]
        public ActionResult<string> GetMe()
        {
            var result = string.Empty;

            if (_httpContextAccessor.HttpContext != null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }

            return Ok(result);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            if (!user.RefreshToken.Equals(refreshToken))
            {
                return Unauthorized("Invalid Refresh Token.");
            }
            else if (user.TokenExpires < DateTime.Now)
            {
                return Unauthorized("Token expired.");
            }

            string token = CreateToken(user);
            var newRefreshToken = GenerateRefreshToken();
            SetRefreshToken(newRefreshToken);

            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDTO userDTO) // username and password
        {
            CreatePasswordHash(userDTO.Password, out byte[] passwordHash, out byte[] passwordSalt);
            // создаем PasswrodHash и PasswordSalt для текущего статического объекта
            user.UserName = userDTO.UserName;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            // вносим данные для хранения в статическом объекте
            _context.Users.Add(user);
            _context.SaveChanges();
            // добавляем в БД
            return Ok(user);
        }


        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDTO userDTO) // логинимся с помощью username & password
        {
            if (user.UserName != userDTO.UserName)
            {
                return BadRequest("User not found!");
            }
            // если не нашли такой никнейм => отправялем BadRequest("User not Found")

            if (!VerifyPasswordHash(userDTO.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong Password");
            }
            // проверяем введенный пароль
            // создаем Hmac по ключу который передается HMAC512(salt)
            // и провяряем текущий password=>passwordHash с тем, что имеется в user ????

            //параллельно создаем токен
            string token = CreateToken(user);

            var refreshToken = GenerateRefreshToken();
            // создается новый токен => строка, длительность действия, начало создания

            SetRefreshToken(refreshToken);
            // добавляем в куки наш токен и переопределяем строку токена, длительность и начало создания
            
            return Ok(token);
            // возвращаем пользователю токен, с которым далее проводит манипуляции
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

        private void SetRefreshToken(RefreshToken newRefreshToken)
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
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, "Admin")
            };
            // создаем некие "утверждения" - доп.информация о пользователе
            // username
            // Role

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));
            // произвольный ключ в виде byte[] полученных с app.settings.json

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,                         // учетные данные
                expires: DateTime.Now.AddDays(1),       // длительность действия
                signingCredentials: creds);             // ключ шифорвания и алгоритм безопасности
            // генерация токена


            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            // пишемт токен => получаем на выходе string

            return jwt;
        }
    }
}
