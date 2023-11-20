using Microsoft.EntityFrameworkCore;

namespace Sprocket.Models;

public class PostContext : DbContext
{
    public PostContext(DbContextOptions<PostContext> options) 
        : base(options)
    {
        
    }
    
    public DbSet<Post> Posts => Set<Post>();
}