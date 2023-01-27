using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Data.DTO
{
    public class AuthorShortDTO
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string YearsOfLife { get; set; }
    }
}
