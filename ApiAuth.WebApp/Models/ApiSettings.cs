namespace ApiAuth.WebApp.Models;

public record class ApiSettings
{
    public string WebApiUrl { get; set; }

    public string WebApiLoginUrl { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public ApiSettings()
    {
        WebApiUrl = string.Empty;
        WebApiLoginUrl = string.Empty;
        Email = string.Empty;
        Password = string.Empty;
    }
}