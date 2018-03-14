using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;
using LoginRegInC.Models;

namespace LoginRegInC.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [Route("register")]
        public IActionResult Register(User newUser)
        {
            if(ModelState.IsValid)
            {
            string query = $"INSERT INTO Users (firstname, lastname, email, password) VALUES ('{newUser.firstname}', '{newUser.lastname}', '{newUser.email}', '{newUser.password}');";
            DbConnector.Execute(query);
            return RedirectToAction("Success");
            }
                else
            {
            return View("Index");
            }
        }

        [HttpPost]
        [Route("logUser")]
        public IActionResult LogUser(Login user)
        {
            if(ModelState.IsValid)
            {
            string query = $"SELECT * FROM Users where (email ='{user.email}')";
            var exists = DbConnector.Query(query);
                if (exists.Count == 0)
                {
                    ViewBag.Email = "Email not found!";
                    return View ("Login");
                }
                else
                {
                string password = (exists[0]["password"]).ToString();
                if (password !=user.password)
                {
                    ViewBag.Password = "Incorrect password. Please try again.";
                    return View("login");
                }
                else
                {
                int id = (int) exists[0]["id"];             
                HttpContext.Session.SetInt32("id", id);             
                string name = (exists[0]["firstname"]).ToString();          
                HttpContext.Session.SetString("user", name);            
                return RedirectToAction("Success");        
                } 
            }    
        }

        else{
            ViewBag.Email = "";
            ViewBag.Password = "";
            return View("login");
        }
    }



        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View("Login");
        }
        

        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
            ViewBag.Name = HttpContext.Session.GetString("user");
            return View();
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
