using Microsoft.EntityFrameworkCore;

namespace Clavier.Models;

public class PageContext : DbContext
{
    public PageContext(DbContextOptions<PageContext> options) 
        : base(options)
    {
        
    }

    public DbSet<Page> Collections => Set<Page>();
}