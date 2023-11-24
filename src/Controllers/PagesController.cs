using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Sprocket.Models;
using Page = Sprocket.Models.Page;

namespace Sprocket.Controllers;


[ApiVersion( 1.0 )]
[ApiController]
[Route("api/[controller]" )]
public class PagesController : ControllerBase
{
    private readonly ILogger<PagesController> _logger;
    private readonly ApplicationDbContext _dbContext;

    public PagesController(ILogger<PagesController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }
    
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Page>> GetPage(int id)
    {
        var page = await _dbContext.Pages.FindAsync(id);

        if (page is null)
        {
            return NotFound();
        }

        return page;
    }

    
    [HttpGet]
    public async Task<List<Page>> ListPages()
    {
        var pages = await _dbContext.Pages.ToListAsync();
        return pages;
    }
    
    
    [Authorize (Roles = "Admin")]
    [HttpPost("new")]
    public async Task<ActionResult<Page>> CreatePage(Page page)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        _dbContext.Pages.Add(page);
        await _dbContext.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetPage), new { id = page.Id }, page);
    }
}