namespace FastLinker.Application.Contracts.Services;

public interface IUrlShortenerService
{
    string ShortenUrl(string originalUrl);
}
