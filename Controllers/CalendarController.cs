using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JatraApplication.Controllers
{
    public class CalendarController : Controller
    {
        [HttpGet]
        public IActionResult Index(int month = 1)
        {
            using (StreamReader r = new StreamReader("../JatraApplication/CalendarJson/1.json"))
            {
                string json = r.ReadToEnd();
                List<CalendarData> calendarInfo = JsonConvert.DeserializeObject<List<CalendarData>>(json);
            }
            return PartialView();
        }
    }

    public class Metadata
    {
        public string en { get; set; }
        public string np { get; set; }
    }

    public class Day
    {
        public string n { get; set; }
        public string e { get; set; }
        public string t { get; set; }
        public string f { get; set; }
        public bool h { get; set; }
        public int d { get; set; }
    }

    public class CalendarData
    {
        public Metadata metadata { get; set; }
        public Day[] days { get; set; }
        public string[] holiFest { get; set; }
        public string[] marriage { get; set; }
        public string[] bratabandha { get; set; }
    }



}
