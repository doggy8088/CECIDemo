using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppSettings appSettings;

        public HomeController(ILogger<HomeController> logger,
            AppSettings appSettings) 
        {
            _logger = logger;
            this.appSettings = appSettings;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            //throw new Exception("BAD");
            ViewBag.SMTPAddress = appSettings.SMTPAddress;

            return View();
        }

        public IActionResult Privacy1()
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