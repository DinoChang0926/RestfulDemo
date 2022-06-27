using Microsoft.EntityFrameworkCore;
using RestfulDemo.Models;

namespace RestfulDemo.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext (DbContextOptions Options):base (Options)
        {

        }
        public DbSet<Member> Members { get; set; }
    }
}
