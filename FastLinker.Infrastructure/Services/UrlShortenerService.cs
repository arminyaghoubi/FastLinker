using FastLinker.Application.Contracts.Services;
using System.Text;
using System;

namespace FastLinker.Infrastructure.Services;

public class UrlShortenerService : IUrlShortenerService
{
    private readonly string AllowedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    private readonly Random random = new Random();
    private readonly HashSet<string> UsedShortUrls = new HashSet<string>();

    public string ShortenUrl(string originalUrl)
    {
        string shortenedUrl;

        do
        {
            shortenedUrl = GenerateRandomString(8);
        } while (UsedShortUrls.Contains(shortenedUrl));

        UsedShortUrls.Add(shortenedUrl);
        return shortenedUrl;
    }

    private string GenerateRandomString(int length)
    {
        StringBuilder randomString = new StringBuilder();

        for (int i = 0; i < length; i++)
        {
            int randomIndex = random.Next(0, AllowedCharacters.Length);
            randomString.Append(AllowedCharacters[randomIndex]);
        }

        return randomString.ToString();
    }
}
