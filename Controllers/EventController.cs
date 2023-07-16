using JatraApplication.IService.Events;
using JatraApplication.Service.Events;
using Microsoft.AspNetCore.Mvc;

namespace JatraApplication.Controllers
{
    public class EventController : Controller
    {
        public IEventDetailsService _eventDetailsService;
        public EventController(IEventDetailsService eventDetailsService)
        {
            _eventDetailsService = eventDetailsService;
        }

        
        public IActionResult GetEventDetails(int eventId)
        {
            var data = _eventDetailsService.GetDetails(eventId);
            return View(data);
        }
    }
}
