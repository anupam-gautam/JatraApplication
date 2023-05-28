using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using JatraApplication.Models.Calendar;

namespace JatraApplication.Controllers
{
    public class CalendarController : Controller
    {
        //private string calendarData;

        [HttpGet]
        public IActionResult Index(int month = 1)
        {
            string json;
            CalendarData calendarInfo;
            using (StreamReader r = new StreamReader("JatraApplication/CalendarJson/1.json"))
            {
                json = r.ReadToEnd();
                calendarInfo = JsonConvert.DeserializeObject<CalendarData>(json);
            }
            ViewBag.calendarInfo = calendarInfo; // Corrected syntax
            return PartialView("_calendarPreview");
            return View("_calendarPreview");
        }
    }
}
