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
            int? check = HttpContext.Session.GetInt32("Counter");
            System.Console.WriteLine(check);
            if (check == null)
            {
            HttpContext.Session.SetInt32("Counter",(int)0);   
            }
            TempData["count"] = HttpContext.Session.GetInt32("Counter");
            Console.WriteLine(TempData["count"]);

            return View();
        }

        [HttpPost]
        [Route("generate")]
        public IActionResult Generate()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string passcode = "";
            Random rand = new Random();
            for( int i = 1; i < 15; i++)
            {
                int x = rand.Next(0,36);
                passcode += chars[x];
            }
          
           TempData["passcode"] = passcode;


            int? count = HttpContext.Session.GetInt32("Counter");   
            count +=1;
            HttpContext.Session.SetInt32("Counter", (int) count);
            return RedirectToAction("Index");
    
        }


    }
}