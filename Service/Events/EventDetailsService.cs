using JatraApplication.IService.Events;
using JatraApplication.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace JatraApplication.Service.Events
{
    public class EventDetailsService : IEventDetailsService 
    {
        private readonly JatraDbContext _context;

        public EventDetailsService(JatraDbContext context)
        {
            _context = context;
        }

        public Event GetDetails(int eventId)
        {
            var queryEvent = (from e in _context.Events.Where(a => a.EventId == eventId)
                              select new
                              {
                                  e.EventName,
                                  e.EventId,
                                  e.EventLocation,
                                  e.EventDescription,
                                  e.EventStartDate,
                                  e.EventEndDate,
                                  e.EventCommunity,
                                  e.EventHighlights
                              });
            var result = queryEvent.Select(n => new Event
            {
                EventId = eventId,
                EventLocation = n.EventLocation,
                EventDescription = n.EventDescription,
                EventStartDate = n.EventStartDate,
                EventEndDate = n.EventEndDate,
                EventCommunity = n.EventCommunity,
                EventHighlights = n.EventHighlights
            }).ToList().FirstOrDefault();
            return result;
        }
    }
}
