using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace WeddingPlanner.Controllers
{
    public class WeddingController : Controller
    {
        private WeddingContext _context;

        public WeddingController(WeddingContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("weddings")]
        public IActionResult Weddings()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId != null)
            {
                List<Wedding> allWeddings = _context.Weddings
                    .Include(wedding => wedding.User)
                    .Include(Wedding => Wedding.RSVPS)
                        .ThenInclude(RSVP => RSVP.User).ToList();
                List<Dictionary<string,object>> WeddingList = new List<Dictionary<string,object>>();

                foreach(Wedding wedding in allWeddings)
                {
                    bool Owned = false;
                    bool RSVPED = false;
                    int RSVPS = 0;

                if (HttpContext.Session.GetInt32("UserId")== wedding.UserId)
                {
                    Owned = true;
                }

                foreach (var rsvp in wedding.RSVPS)
                {
                    if (rsvp.UserId == HttpContext.Session.GetInt32("UserId"))
                    {
                        RSVPED = true;
                    }
                    RSVPS++;
                }

                Dictionary<string,object> newWeddingAdd = new Dictionary<string,object>();
                newWeddingAdd.Add("WeddingId" , wedding.WeddingId);
                newWeddingAdd.Add("WedderOne" , wedding.WedderOne);
                newWeddingAdd.Add("WedderTwo" , wedding.WedderTwo);
                newWeddingAdd.Add("Date" , wedding.Date);
                newWeddingAdd.Add("Address" , wedding.Address);
                newWeddingAdd.Add("Owned" , Owned);
                newWeddingAdd.Add("RSVPS" , RSVPS);
                newWeddingAdd.Add("RSVPED" , RSVPED);
                WeddingList.Add(newWeddingAdd);
                }
                ViewBag.Weddings = WeddingList;;
                return View("Weddings");
            }
            else
            {
                return RedirectToAction("Index", "User");
            }
        }

        [HttpGet]
        [Route("rsvp/{RSVPid}")]
        public IActionResult RSVP(int RSVPid)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if(UserId == null) 
            {
                return RedirectToAction("Index", "User");
            }
            else
            {
                RSVP newrsvp = new RSVP
                {
                    UserId = (int) UserId,
                    WeddingId = RSVPid
                };
                RSVP Reservation = _context.Add(newrsvp).Entity;
                _context.SaveChanges();
                return RedirectToAction("Weddings");
            } 
        }

        [HttpGet]
        [Route("addWedding")]

        public IActionResult AddWedding()

        {
            return View("AddWedding");
        }

        [HttpGet]
        [Route("delete/{WeddingId}")]
        public IActionResult Delete(int WeddingId)
        {
            Wedding deleteWedding = _context.Weddings.SingleOrDefault
            ( w=> w.UserId == (int)HttpContext.Session.GetInt32("UserId") 
            && w.WeddingId == WeddingId);   
            if(deleteWedding != null) 
            {
            _context.Weddings.Remove(deleteWedding);
            _context.SaveChanges();
            }
            return RedirectToAction("Weddings");
        }

        [HttpGet]
        [Route("show/{WeddingId}")]
        public IActionResult Show(int WeddingId)
        {
           
            Wedding thisWedding = _context.Weddings
            .Include(w=>w.RSVPS)
            .ThenInclude(r=>r.User)
            .SingleOrDefault(w=>w.WeddingId==WeddingId);
            ViewBag.ThisWedding = thisWedding;
            return View("Show");
        }

        [HttpGet]
        [Route("reserve/{WeddingId}")]
        public IActionResult Reserve(int WeddingId)
        {
           RSVP newRSVP = new RSVP
           {
                UserId=(int)HttpContext.Session.GetInt32("UserId"),
                WeddingId = WeddingId
           };
           RSVP existingRSVP = _context.RSVPS.SingleOrDefault
           (r => r.UserId == (int)HttpContext.Session.GetInt32("UserId")&& r.WeddingId == WeddingId);
           if (existingRSVP == null)
           {
               _context.RSVPS.Add(newRSVP);
               _context.SaveChanges();
           }
           return RedirectToAction("Weddings");
        }

        [HttpGet]
        [Route("unrsvp/{WeddingId}")]
        public IActionResult UnRSVP(int WeddingId)
        {
            RSVP negative = _context.RSVPS.SingleOrDefault
            (r => r.UserId == (int)HttpContext.Session.GetInt32("UserId")&& r.WeddingId == WeddingId);

            if(negative != null)
            {
                _context.RSVPS.Remove(negative);
                _context.SaveChanges();
            }
            return RedirectToAction("Weddings");
        }


        [HttpPost]
        [Route("createWedding")]
        public IActionResult createWedding(Wedding model)
        {
            if (ModelState.IsValid)
            {
                Wedding newWedding = new Wedding
                {
                    UserId = (int)HttpContext.Session.GetInt32("UserId"),
                    WedderOne = model.WedderOne,
                    WedderTwo = model.WedderTwo,
                    Date = model.Date,
                    Address = model.Address
                };
                _context.Add(newWedding);
                _context.SaveChanges();
                return RedirectToAction("Weddings");
            }
            else
            {
                return View("AddWedding");
            }
        }
    }
}