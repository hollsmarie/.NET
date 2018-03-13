using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;

namespace PostedNotes.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            string query = "SELECT * from Notes";
            var notes = DbConnector.Query(query);
            ViewBag.Notes = notes;
            return View();
        }

        [HttpPost]
        [Route("postNotes")]
        public IActionResult Post(string Title, string Description)
        {
            string query = $"INSERT into Notes(Title, Description, CreatedAt, UpdatedAt) VALUES ('{Title}', '{Description}',  NOW(), NOW())";
            DbConnector.Execute(query);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {
            string query = $"SELECT * FROM Notes WHERE id={id}";
            var note = DbConnector.Query(query);
            ViewBag.Edit = note;
            return View("edit");
        }


        [HttpPost]
        [Route("update/{id}")]
        public IActionResult Update(string Title, string Description,int id)
        {
            string query = $"UPDATE Notes SET Title='{Title}', Description='{Description}', UpdatedAt=NOW() WHERE id={id}";
            DbConnector.Execute(query);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            string query = $"DELETE FROM Notes WHERE id={id}";
            DbConnector.Execute(query);
            return RedirectToAction("Index");
        }
    }
}
