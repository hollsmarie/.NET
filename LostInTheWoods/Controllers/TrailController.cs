using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LostInTheWoods.Factory;
using LostInTheWoods.Models;

namespace LostInTheWoods.Controllers
{
    public class TrailController : Controller
    {

        private readonly TrailFactory trailFactory;
        public TrailController()
        {
            trailFactory = new TrailFactory();
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Trails = trailFactory.FindAll();
            return View();
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("addTrail")]
        public IActionResult addTrail(Trail newTrail)
        {
            trailFactory.Add(newTrail);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("show/{id}")]
        public IActionResult ViewTrail(int id)
        {
            ViewBag.Trail = trailFactory.FindByID(id);
            return View();
        }

        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            trailFactory.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
