using JatraApplication.Models;
using JatraApplication.Models.Calendar;
using Microsoft.AspNetCore.Mvc;
using NepaliCalendarBS;
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

        public IActionResult Index(int? month)
        {
            string json;
            CalendarData calendarInfo;
            var curDate = NepaliCalendar.TodayBS();
            month = (month == null) ? curDate.Month : month;
            using (StreamReader r = new StreamReader("../JatraApplication/CalendarJson/" + month.ToString() + ".json"))
            {
                json = r.ReadToEnd();
                calendarInfo = JsonConvert.DeserializeObject<CalendarData>(json);
            }
            ViewBag.calendarInfo = calendarInfo; // Corrected syntax
            ViewBag.currMonth = month;
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




    public enum Nepali_Months
    {
        Baishakh,    // 0
        Jestha,   // 1
        Asar,      // 2
        Shrawan,      // 3
        Bhadra,        // 4
        Asoj,       // 5
        Kartik,        // 6
        Mangsir,
        Poush,
        Magh,
        Falgun,
        Chaitra
    }

    public enum English_Months
    {
        January,    // 0
        February,   // 1
        March,      // 2
        April,      // 3
        May,        // 4
        June,       // 5
        July,        // 6
        August,
        September,
        October,
        November,
        December
    }

    public enum WeekDays
    {
        Sun,
        Mon,
        Tue,
        Wed,
        Thrus,
        Fri,
        Sat
    }


}