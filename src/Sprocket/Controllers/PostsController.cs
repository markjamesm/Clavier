using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Sprocket.Models;

namespace Sprocket.Controllers;


[ApiVersion( 1.0 )]
[ApiController]
[Route("api/[controller]" )]
public class PostsController : ControllerBase
{
    private readonly ILogger<PagesController> _logger;
    private readonly ApplicationDbContext _dbContext;

    public PostsController(ILogger<PagesController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }
    
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<PostDto>> GetPost(int id)
    {
        var post = await _dbContext.Posts.FindAsync(id);

        if (post is null)
        {
            return NotFound();
        }
        
        var postDto = new PostDto
        {
            Id = post.Id,
            Author = post.Author,
            Body = post.Body,
            Title = post.Title
        };

        return postDto;
    }

    
    [HttpGet]
    public async Task<PostsDto> ListPosts()
    {
        var postsFromDb = await _dbContext.Posts.ToListAsync();
        
        var postsDto = new PostsDto();
        
        foreach (var post in postsFromDb)
        {
            var postDto = new PostDto
            {
                Id = post.Id,
                Author = post.Author,
                Body = post.Body,
                Title = post.Title
            };
            
            postsDto.Posts.Add(postDto);
        }
        
        return postsDto;
    }
    
    
    [Authorize (Roles = "Admin")]
    [HttpPost("new")]
    public async Task<ActionResult<Page>> CreatePost(PostDto postDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var post = new Post
        {
            Id = postDto.Id,
            Title = postDto.Title,
            Author = postDto.Author,
            Body = postDto.Body,
        };
        
        _dbContext.Posts.Add(post);
        await _dbContext.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
    }
}