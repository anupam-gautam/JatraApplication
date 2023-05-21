using JatraApplication.Models;
using JatraApplication.Models.Calendar;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace JatraApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string json;
            CalendarData calendarInfo;
            using (StreamReader r = new StreamReader("CalendarJson/1.json"))
            {
                json = r.ReadToEnd();
                calendarInfo = JsonConvert.DeserializeObject<CalendarData>(json);
            }
            ViewBag.calendarInfo = calendarInfo; // Corrected syntax
            return View();
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