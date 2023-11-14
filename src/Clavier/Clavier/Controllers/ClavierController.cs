using Microsoft.AspNetCore.Mvc;

namespace Clavier.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ClavierController : ControllerBase
{
    private readonly ILogger<ClavierController> _logger;

    public ClavierController(ILogger<ClavierController> logger)
    {
        _logger = logger;
    }

    [HttpGet("status")]
    public string Get()
    {
        return """
               { 
                "status": "⋆𝄞⋆ Clavier is operational! ⋆𝄞⋆" 
               }
               """;
    }
}