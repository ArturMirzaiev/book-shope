using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Data.Classes
{
    public class RefreshToken
    {
        public string Token { get; set; } = String.Empty;
        public DateTime Created { get; set; }
        public DateTime Expires { get; set; }
    }
}
