using ApiAuth.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace ApiAuth.WebApp.Controllers
{
    public class HomeController(IHttpClientFactory factory, IOptionsMonitor<ApiSettings> options) : Controller
    {
        private readonly IHttpClientFactory _factory = factory;
        private readonly ApiSettings _settings = options.CurrentValue;

        public async Task<IActionResult> Index()
        {
            using var client = _factory.CreateClient();
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
}