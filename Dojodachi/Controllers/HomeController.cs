using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Identity;
 
namespace RandomPasscode.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            int? happylevel = HttpContext.Session.GetInt32("Happiness");
            int? fulllevel = HttpContext.Session.GetInt32("Fullness");
            int? energylevel = HttpContext.Session.GetInt32("Energy");
            int? meallevel = HttpContext.Session.GetInt32("Meals");
           
            if(happylevel == null)
            {
            HttpContext.Session.SetInt32("Happiness",(int)20); 
            HttpContext.Session.SetInt32("Fullness",(int)20); 
            HttpContext.Session.SetInt32("Energy",(int)50); 
            HttpContext.Session.SetInt32("Meals",(int)3); 
            TempData["lose"] = "";
            TempData["win"] = "";
            TempData["action"] = "";
            string action = "";
            TempData["action"] = $"Welcome! If Lola's Happiness, Energy, and Fullness all reach 100, you win! If her Fullness or Happiness reach 0, you lose.";
            
            }

            if(happylevel <= 0|| fulllevel <= 0)
            {
                string lose = "Sorry, you lose!";
                TempData["lose"] = lose;
            }

             if(happylevel >= 100 && fulllevel >= 100 && energylevel >= 100)
            {
                string win = "Yay, you win!";
                TempData["win"] = win;
            }

            TempData["happylevel"] = HttpContext.Session.GetInt32("Happiness");
            TempData["fulllevel"] = HttpContext.Session.GetInt32("Fullness");
            TempData["energylevel"] = HttpContext.Session.GetInt32("Energy");
            TempData["meallevel"] = HttpContext.Session.GetInt32("Meals");

           
            return View();
        }

        [HttpPost]
        [Route("feed")]
        public IActionResult Feed()
        {
            int? fulllevel = HttpContext.Session.GetInt32("Fullness");
            int? meallevel = HttpContext.Session.GetInt32("Meals");

            if (fulllevel > 4)
            { 
            Random rand = new Random();
            int fullrandom = rand.Next(5,11);
            fulllevel += fullrandom; 
            meallevel -= 1;
            string action = "";
            TempData["action"] = $"YUM! Lola's fullness has increased by {fullrandom}! Careful, she has {meallevel} meals left! ";
            


            }
            else{ 
            
            Random rand = new Random();
            int fullrandom = rand.Next(5,11);
            fulllevel += fullrandom; 
            }

            HttpContext.Session.SetInt32("Fullness", (int)fulllevel);
            HttpContext.Session.SetInt32("Meals", (int)meallevel);

        return RedirectToAction("Index");
    
        }

        [HttpPost]
        [Route("play")]
        public IActionResult Play()
        {

        int? happylevel = HttpContext.Session.GetInt32("Happiness");
        int? energylevel = HttpContext.Session.GetInt32("Energy");

        if (happylevel > 4)
            { 
            Random rand = new Random();
            int happyrandom = rand.Next(5,11);
            happylevel += happyrandom; 
            energylevel -= 5;
            string action = "";
            TempData["action"] = $"Lola loves to play, you've increased her Happiness by {happyrandom}! But now she's tired and only has {energylevel} energy points. ";
            
            }


        HttpContext.Session.SetInt32("Happiness", (int)happylevel);
        HttpContext.Session.SetInt32("Energy", (int)energylevel);

        return RedirectToAction("Index");
    
        }


        [HttpPost]
        [Route("work")]
        public IActionResult Work()
        {
        
        int? energylevel = HttpContext.Session.GetInt32("Energy");
        int? meallevel = HttpContext.Session.GetInt32("Meals");

        if (energylevel > 4)
            { 
            Random rand = new Random();
            int mealrandom = rand.Next(1,4);
            meallevel += mealrandom; 
            energylevel -= 5;
            string action = "";
            TempData["action"] = $"Boo, Lola hates to work, her energy has decreased to {energylevel}! But she earned {mealrandom} meals! ";
            
            }


        HttpContext.Session.SetInt32("Meals", (int)meallevel);
        HttpContext.Session.SetInt32("Energy", (int)energylevel);

        return RedirectToAction("Index");
    
        }


        [HttpPost]
        [Route("sleep")]
        public IActionResult Sleep()
        {
            int? happylevel = HttpContext.Session.GetInt32("Happiness");
            int? fulllevel = HttpContext.Session.GetInt32("Fullness");
            int? energylevel = HttpContext.Session.GetInt32("Energy");
            
            if (happylevel > 4)
            { 
            happylevel  -= 5; 
            fulllevel -=5 ; 
            energylevel +=15; 
            string action = "";
            TempData["action"] = $"Phew! Lola was tired, that sleep increased her energy to {energylevel}! Her Happiness has decreased to {happylevel} and her Fullness has decreased to {fulllevel}! ";
            
            }
            HttpContext.Session.SetInt32("Happiness", (int)happylevel);
            HttpContext.Session.SetInt32("Fullness", (int)fulllevel);
            HttpContext.Session.SetInt32("Energy", (int)energylevel);

        return RedirectToAction("Index");
    
        }

        [HttpPost]
        [Route("reset")]
        public IActionResult Reset()
        
        { 

        HttpContext.Session.Clear();
        return RedirectToAction("Index");
        }
    


    }
}