using ApiAuth.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ApiAuth.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _factory;

        public HomeController(IHttpClientFactory factory) => _factory = factory;

        public async Task<IActionResult> Index()
        {
            using var client = _factory.CreateClient();
            var students = await client.GetFromJsonAsync<IEnumerable<Student>>("http://localhost:5139/student");
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