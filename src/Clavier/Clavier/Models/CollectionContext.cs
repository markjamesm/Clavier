using Microsoft.EntityFrameworkCore;

namespace Clavier.Models;

public class CollectionContext : DbContext
{
    public CollectionContext(DbContextOptions<CollectionContext> options) 
        : base(options)
    {
        
    }

    public DbSet<Collection> Collections => Set<Collection>();
}