using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WeddingPlanner.Models;
using System.Linq;

namespace WeddingPlanner.Controllers
{
    public class UserController : Controller
    {
        private WeddingContext _context;

        public UserController(WeddingContext context)
        {
            _context = context;
        }
     
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId != null)
            {
                return RedirectToAction("Success");
            }
            else
            {
            return View();
            }
        }


        [HttpPost]
        [Route("Register")]
        public IActionResult Register(Register model)
        {
            if(ModelState.IsValid)
            {
                
                    User ExistingUser = _context.Users.SingleOrDefault(user => user.email == model.email);
                    if(ExistingUser != null)
                    {
                        ModelState.AddModelError("Email", "An account with this email already exists!");
                        return View("Index");
                    }
                User newUser = new User
                {
                    firstname = model.firstname,
                    lastname = model.lastname,
                    email = model.email,
                    password = model.password
                };
                _context.Add(newUser);
                _context.SaveChanges();
                newUser = _context.Users.SingleOrDefault( user => user.email == newUser.email);
                HttpContext.Session.SetInt32 ("UserId", newUser.UserId);     
                HttpContext.Session.SetString("user", newUser.firstname);     
                return RedirectToAction("Success");
            }
            else
            {
            return View("Index", model);
            }
        }


        [HttpGet]
        [Route("Success")]
        public IActionResult Success()
        {
            ViewBag.Name = HttpContext.Session.GetString("user");
            return View("Success");
        }


        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
        
             return View("Login");
            
        }



        [HttpPost]
        [Route("logUser")]
        public IActionResult LogUser(string email, string password)
        {
            User FoundUser = _context.Users.SingleOrDefault(user => user.email == email && user.password == password);  
            if(FoundUser == null)
            {
                ModelState.AddModelError("Email", "Sorry, that user doesn't exist.");
                return View("Index");
            }
            else
            {
               HttpContext.Session.SetInt32("UserId", FoundUser.UserId);
               HttpContext.Session.SetString("user", FoundUser.firstname);  
               return RedirectToAction("Success");
            }
        }


        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

    }
}
