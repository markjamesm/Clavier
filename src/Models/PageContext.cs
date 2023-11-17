using Microsoft.EntityFrameworkCore;

namespace Sprocket.Models;

public class PageContext : DbContext
{
    public PageContext(DbContextOptions<PageContext> options) 
        : base(options)
    {
        
    }

    public DbSet<Page> Pages => Set<Page>();
}