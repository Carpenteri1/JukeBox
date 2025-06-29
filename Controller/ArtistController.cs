using JukeBox.QueryModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JukeBox.Controller;

/// <summary>
/// Handles artist-related data access
/// </summary>
[ApiController]
[Route("api/artist")]
public class ArtistController(IMediator mediator) : ControllerBase
{

    [HttpGet("id")]
    public async Task<IActionResult> GetById([FromQuery] string? id)
    {
        if (!string.IsNullOrWhiteSpace(id))
        {
            var result = await mediator.Send(new ArtistQuery.GetById(id));
            return result is null ? NotFound() : Ok(result);
        }
        return BadRequest("Provide either id for the artist");
    }
    
    [HttpGet("wikidata")]
    public async Task<IActionResult> GetWikidataById([FromQuery] string? id)
    {
        if (!string.IsNullOrWhiteSpace(id))
        {
            var result = await mediator.Send(new ArtistQuery.GetWikiData(id));
            return result is null ? NotFound() : Ok(result);
        }
        
        return BadRequest("Provide id for the wikidata");
    }
    
    [HttpGet("summery")]
    public async Task<IActionResult> GetWikiDataSummery([FromQuery] string? enwikiTitle)
    {
        if (!string.IsNullOrWhiteSpace(enwikiTitle))
        {
            var result = await mediator.Send(new ArtistQuery.GetWikipediaSummary(enwikiTitle));
            return result is null ? NotFound() : Ok(result);
        }
        
        return BadRequest("Provide id for the wikidata");
    }
}