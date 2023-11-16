using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using Sprocket.Models;

namespace Sprocket.Controllers;


[ApiVersion( 1.0 )]
[ApiController]
[Route("api/[controller]" )]
public class PageController : ControllerBase
{
    private readonly ILogger<PageController> _logger;
    private readonly PageContext _dbContext;

    public PageController(ILogger<PageController> logger, PageContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }
    
    [HttpGet]
    public async Task<ActionResult<Page>> GetPage(int id)
    {
        var todoItem = await _dbContext.Collections.FindAsync(id);

        if (todoItem is null)
        {
            return NotFound();
        }

        return todoItem;
    }
    
    [HttpPost]
    public async Task<ActionResult<Page>> PostPage(Page page)
    {
        _dbContext.Collections.Add(page);
        await _dbContext.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetPage), new { id = page.Id }, page);
    }
}