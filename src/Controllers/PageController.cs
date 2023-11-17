using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
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
    
    [HttpGet, Authorize]
    public async Task<ActionResult<Page>> GetPage(int id)
    {
        var todoItem = await _dbContext.Pages.FindAsync(id);

        if (todoItem is null)
        {
            return NotFound();
        }

        return todoItem;
    }
    
    [HttpPost, Authorize]
    public async Task<ActionResult<Page>> PostPage(Page page)
    {
        _logger.LogInformation("Hitting endpoint");
        _dbContext.Pages.Add(page);
        await _dbContext.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetPage), new { id = page.Id }, page);
    }
}