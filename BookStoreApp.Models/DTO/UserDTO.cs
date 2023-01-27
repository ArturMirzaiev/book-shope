using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookStoreApp.Data.DTO
{
    public class UserDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        [JsonIgnore]
        public string Token { get; set; } = string.Empty;
        [JsonIgnore]
        public string Role { get; set; } = "User";
    }
}
