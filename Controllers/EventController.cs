using JatraApplication.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;

namespace JatraApplication.Controllers
{
    public class EventController : Controller
    {
        private readonly JatraDbContext _context;

        public EventController(JatraDbContext dbContext)
        {
            _context = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EventList()
        {
            var data = _context.Events.ToList();
            return View();
        }
    }
}
