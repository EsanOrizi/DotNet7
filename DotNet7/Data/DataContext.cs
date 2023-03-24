using DotNet7.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet7.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
                        
        }

        public DbSet<Character> Characters => Set<Character>();
    }
}
