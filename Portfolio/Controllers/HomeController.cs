using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("home")]
        public IActionResult Home()
        {
            return View();
        }

        [Route("projects")]
        [HttpGet]
        public IActionResult Projects()
        {
            return View();
        }

        [Route("contact")]
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

    }
}