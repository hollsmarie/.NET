using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace CallingCard.Controllers
{
    public class MyController : Controller
    {
        [HttpGet]
        [Route("")]
        public string Home()
        {
            return "This is Home page of Calling Card. Enter name/lastName/age/color";
        }

        [HttpGet]
        [Route("first")]
        public string first()
        {
            return "Holly";
        }


        [HttpGet]
        [Route("last")]
        public string last()
        {
            return "Valenty";
        }

        [HttpGet]
        [Route("age")]
        public string age()
        {
            return "27";
        }

        [HttpGet]
        [Route("color")]
        public string color()
        {
            return "green";
        }

        [HttpGet]
        [Route("first/last/age/color")]
        public JsonResult DisplayPerson(string first, string last, int age, string color)
        {
          var AnonObject = new 
          {
              first = "Holly",
              last = "Valenty",
              age = 27,
              color = "green"
          };
          return Json(AnonObject);
        }
    }
}