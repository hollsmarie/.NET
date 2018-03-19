using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RESTauranter.Models;
using System.Linq;


namespace RESTauranter.Controllers
{
    public class ReviewController : Controller
    {
        private ReviewContext _context;

        public ReviewController(ReviewContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("LeaveReview")]
        public IActionResult LeaveReview(Review newReview)
        {
            if(ModelState.IsValid)
            {
            _context.Add(newReview);
            _context.SaveChanges();
            return RedirectToAction("Reviews");
            }
            else
            {
            return View ("Index");
            }
        }

        [HttpGet]
        [Route("Reviews")]
        public IActionResult Reviews()
        {
            List<Review> allReviews = _context.Reviews.OrderByDescending(r => r.VisitDate).ToList();
            ViewBag.Reviews = allReviews;
            return View();
        }
    }
}
