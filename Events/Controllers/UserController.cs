using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Events.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace Events.Controllers
{
    public class UserController : Controller
    {
        private EventContext _context;

        public UserController(EventContext context)
        {
            _context = context;
        }
     

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }




        [HttpPost]
        [Route("Register")]
        public IActionResult Register(UserViewModels model)
        {
            if(ModelState.IsValid)
            {   
                User ExistingUser = _context.Users.SingleOrDefault(user => user.email == model.Reg.email);
                if(ExistingUser != null)
                {
                    ModelState.AddModelError("Reg.Email", "An account with this email already exists!");
                    return View("Index");
                }
                PasswordHasher<UserViewModels> hasher = new PasswordHasher<UserViewModels>();
                string hashed = hasher.HashPassword (model, model.Reg.password);
                User newUser = new User
                {
                    firstname = model.Reg.firstname,
                    lastname = model.Reg.lastname,
                    email = model.Reg.email,
                    password = hashed
                };
                _context.Add(newUser);
                _context.SaveChanges();
                newUser = _context.Users.SingleOrDefault( user => user.email == newUser.email);
                HttpContext.Session.SetInt32 ("UserId", newUser.UserId);     
                HttpContext.Session.SetString("user", newUser.firstname);     
                return RedirectToAction("Dashboard", "Event");
            }
            else
            {
            return View("Index");
            }
        }


        [HttpPost]
        [Route("logUser")]
        public IActionResult LogUser(UserViewModels model)
        {
            if(ModelState.IsValid)
            {
            User FoundUser = _context.Users.SingleOrDefault(user => user.email == model.Login.email);  
            if(FoundUser == null)
            {
                ModelState.AddModelError("Email", "Sorry, that user doesn't exist.");
                return View("Index");
            }
            PasswordHasher<User> hasher = new PasswordHasher<User>();
            if(hasher.VerifyHashedPassword(FoundUser, FoundUser.password, model.Login.password) == 0)
            {
                ModelState.AddModelError("Login", "Incorrect password.");
                return View("Index"); 
            }
            HttpContext.Session.SetInt32("UserId", FoundUser.UserId);
            HttpContext.Session.SetString("user", FoundUser.firstname); 
            return RedirectToAction("Dashboard", "Event");
            }
            return View("Index");
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