using JukeBox.Models;

namespace JukeBox.Endpoints;

public interface IArtistEndPoint
{
    public Task<ArtistDto> GetById(string id);
    public Task<WikiDataDto> GetWikiData(string id);
    public Task<WikipediaSummaryDto> GetWikipediaSummary(string enwikiTitle);
}