namespace ApiAuth.WebApp.Models;

public record class ApiSettings
{
    public string WebApiUrl { get; set; }

    public ApiSettings() => WebApiUrl = string.Empty;
}