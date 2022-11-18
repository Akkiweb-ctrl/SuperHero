
using Microsoft.EntityFrameworkCore;
namespace SuperHeroApi.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options):base(options) { }
        public DbSet<SuperHero> SuperHeroes => Set<SuperHero>();

        public object GetSuperHeroes { get; internal set; }
    }
}
