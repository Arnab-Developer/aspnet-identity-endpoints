namespace ApiAuth.WebApp.Models;

public record class LoginResponse
{
    [JsonPropertyName("tokenType")]
    public string TokenType { get; set; }

    [JsonPropertyName("accessToken")]
    public string AccessToken { get; set; }

    [JsonPropertyName("expiresIn")]
    public int ExpiresIn { get; set; }

    [JsonPropertyName("refreshToken")]
    public string RefreshToken { get; set; }

    public LoginResponse()
    {
        TokenType = string.Empty;
        AccessToken = string.Empty;
        ExpiresIn = 0;
        RefreshToken = string.Empty;
    }
}