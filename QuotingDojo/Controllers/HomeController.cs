using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;
using QuotingDojo;


namespace QuotingDojo.Controllers
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
         
        [HttpGet]
        [Route("quotes")]
        public IActionResult AddQuotes()
        {
            string query = "SELECT * from Quote";
            var quotes = DbConnector.Query(query);
            ViewBag.Quotes = quotes;
            System.Console.WriteLine(quotes);
            
            return View("quotes");
        }

        [HttpPost]
        [Route("quotespost")]
        public IActionResult Quotes(string Name, string Quote)
        {
            string query = $"INSERT into Quote(Name, Quote) VALUES ('{Name}', '{Quote}')";
            DbConnector.Execute(query);

            return Redirect("quotes");
        }
    }
}
