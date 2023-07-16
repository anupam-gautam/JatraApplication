using JatraApplication.Models;
using JatraApplication.Models.Calendar;
using JatraApplication.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NepaliCalendarBS;
using Newtonsoft.Json;
using System.Diagnostics;

namespace JatraApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly JatraDbContext _context;


        public HomeController(ILogger<HomeController> logger, JatraDbContext context)
        {
            _logger = logger;
            _context = context;

        }

        public IActionResult Index(int? month)
        {
            string json;
            CalendarData calendarInfo;
            var curDate = NepaliCalendar.TodayBS();
            month = (month == null) ? curDate.Month : month;
            using (StreamReader r = new StreamReader("CalendarJson/" + month.ToString() + ".json"))
            {
                json = r.ReadToEnd();
                calendarInfo = JsonConvert.DeserializeObject<CalendarData>(json);
            }
            var allEvents = _context.Events.Select(s => new EventViewModel()
            {
                EventId = s.EventId,
                EventName = s.EventName,
                EventDescription = s.EventDescription,
                EventStartDate = s.EventStartDate,
                EventEndDate = s.EventEndDate,
                EventLocation = s.EventLocation,
                EventCommunity = s.EventLocation,
                EventHighlights = s.EventHighlights,
            }).ToList();

            foreach (var i in allEvents)
            {
                foreach (var j in calendarInfo.days)
                {
                    string dateTimeEventDateNepali = Convert.ToString(NepaliCalendar.Convert_AD2BS(Convert.ToDateTime(i.EventStartDate)));
                    DateTime parsedDN = DateTime.Parse(dateTimeEventDateNepali);
                    i.DevnagiriDay = DateTimeHelper.DTfor(parsedDN);


                    if (parsedDN != null && Convert.ToString(parsedDN.Month) == month.ToString() && i.DevnagiriDay == j.n)
                    {
                        j.eventName = i.EventName;
                        j.eventid = i.EventId;
                    }

                }
            }
            NepaliDate convertedDate = NepaliCalendar.Convert_AD2BS(Convert.ToDateTime(allEvents.First().EventStartDate));
            ViewBag.calendarInfo = calendarInfo; // Corrected syntax
            ViewBag.currMonth = month;
            //ViewBag.currMonthEvents = currMonthEvents;
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