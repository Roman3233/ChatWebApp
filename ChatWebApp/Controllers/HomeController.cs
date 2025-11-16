using System.Diagnostics;
using ChatWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatWebApp.Controllers
{
    // Handles navigation for basic site pages such as Index and Privacy.
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Initializes controller with logger from DI container.
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Returns the main chat page.
        public IActionResult Index()
        {
            return View();
        }

        // Returns the Privacy information page.
        public IActionResult Privacy()
        {
            return View();
        }

        // Displays error information based on the current request.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
