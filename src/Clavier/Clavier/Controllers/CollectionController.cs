using Clavier.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clavier.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CollectionController : ControllerBase
{
    private readonly ILogger<CollectionController> _logger;
    private readonly CollectionContext _dbContext;

    public CollectionController(ILogger<CollectionController> logger, CollectionContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }
    
    [HttpGet]
    public async Task<ActionResult<Collection>> GetCollection(int id)
    {
        var todoItem = await _dbContext.Collections.FindAsync(id);

        if (todoItem == null)
        {
            return NotFound();
        }

        return todoItem;
    }
    
    [HttpPost]
    public async Task<ActionResult<Collection>> PostCollection(Collection collection)
    {
        _dbContext.Collections.Add(collection);
        await _dbContext.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetCollection), new { id = collection.Id }, collection);
    }
}