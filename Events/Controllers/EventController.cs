using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Events.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Events.Controllers
{
    public class EventController : Controller
    {

        private EventContext _context;
        public EventController(EventContext context)
        {
            _context = context;
        }

        public int CheckSession()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if(UserId == null)
            {
                return 0;
            }
            return (int)UserId;
        }

        // GET: /Home/
        [HttpGet]
        [Route("dashboard")]
        public IActionResult dashboard()
        {
            if(CheckSession()== 0)
            {
                return RedirectToAction("Index","User");
            }
            User LoggedIn = _context.Users.SingleOrDefault(u => u.UserId == CheckSession());
            ViewBag.User = LoggedIn;
            ViewBag.Events = _context.Events.Include(e => e.Likes).OrderBy( e => e.Date).ToList();
            return View("dashboard");
        }


        [HttpGet]
        [Route("eventForm")]
        public IActionResult EventForm()
        {
            if(CheckSession()== 0)
            {
                return RedirectToAction("Index","User");
            }
            return View();
        }


        [HttpPost]
        [Route("planEvent")]
        public IActionResult Add(Event model)
        {
            if(CheckSession()== 0)
            {
                return RedirectToAction("Index","User");
            }
            if (ModelState.IsValid)
            {
                Event newEvent = new Event
                {
                    Location = model.Location,
                    Host = model.Host,
                    Date = model.Date,
                    Reason = model.Reason
                };
                _context.Add(newEvent);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else
            {
            return View("eventForm");
            }
        }
    
        [HttpGet]
        [Route("like/{EventId}")]
        public IActionResult Like (int EventId)
        {
            if(CheckSession() == 0)
            {
                return RedirectToAction("Index", "User");
            }
            Like like = new Like
            {
                UserId = CheckSession(),
                EventId = EventId
            };
            _context.Add(like);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet]
        [Route("unlike/{EventId}")]
        public IActionResult Unlike (int EventId)
        {
            if(CheckSession() == 0)
            {
                return RedirectToAction("Index", "User");
            }
            Like like = _context.Likes.SingleOrDefault(l => l.UserId == CheckSession() && l.EventId == EventId);
            _context.Remove(like);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet]
        [Route("delete/{EventId}")]
        public IActionResult Delete (int EventId)
        {
            Event deletethis = _context.Events.SingleOrDefault(e=>e.EventId == EventId);
            _context.Remove(deletethis);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }


        [HttpGet]
        [Route("show/{EventId}")]
        public IActionResult Show(int EventId)
        {
            Event thisEvent = _context.Events.Include (e => e.Likes).ThenInclude(l => l.User).SingleOrDefault(e => e.EventId == EventId);
            ViewBag.ThisEvent = thisEvent;
            return View("showEvent");
        }

    }
}