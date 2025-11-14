using Microsoft.AspNetCore.Mvc;

namespace ChatWebApp.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
