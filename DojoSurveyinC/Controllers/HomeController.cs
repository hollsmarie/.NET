using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DojoSurveyinC.Controllers
{

    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("result")]

        public IActionResult Result(string name, string location, string language, string comments)
        {
            ViewBag.name = name;
            ViewBag.location = location;
            ViewBag.language = language;
            ViewBag.comments = comments;

            return View();
        }
    }
}