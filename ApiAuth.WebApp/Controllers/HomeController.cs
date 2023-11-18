using ApiAuth.WebApp.Models;

namespace ApiAuth.WebApp.Controllers;

[Authorize]
public class HomeController(IHttpClientFactory factory, IOptionsMonitor<ApiSettings> options) : Controller
{
    private readonly IHttpClientFactory _factory = factory;
    private readonly ApiSettings _settings = options.CurrentValue;

    public async Task<IActionResult> Index()
    {
        using var client = _factory.CreateClient();
        var user = new User(_settings.Email, _settings.Password);
        var response = await client.PostAsJsonAsync(_settings.WebApiLoginUrl, user);
        response.EnsureSuccessStatusCode();

        var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>() ??
            throw new InvalidOperationException();

        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {loginResponse.AccessToken}");
        var students = await client.GetFromJsonAsync<IEnumerable<Student>>(_settings.WebApiUrl);
        return View(students);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}