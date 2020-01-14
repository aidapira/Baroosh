using Microsoft.EntityFrameworkCore;

namespace Baroosh.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
    }
}