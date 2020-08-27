using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Myweb.Ef_model;

namespace Myweb.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            BlockchainContext db = new BlockchainContext();
            var res = (from x in db.Game select x).ToList();
            ViewBag.games = res;
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            BlockchainContext db = new BlockchainContext();
            var res = (from x in db.Game where x.Id == id select x).FirstOrDefault();
            if (res == null)
            {
                return Content("Miss data");
            }
            else
            {
                db.Game.Remove(res);
                db.SaveChanges();
                return Content("ok");
            } 
        }
        public IActionResult AddGame(IFormCollection fc)
        {
            string name = fc["name"];
            string description = fc["description"];
            BlockchainContext db = new BlockchainContext();
            Game game = new Game
            {
                Name = name,
                Description = description
            };
            db.Game.Add(game);
            int number = db.SaveChanges();
            if (number == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Add");
            }
        }

        public IActionResult GameEdit(int id)
        {
            BlockchainContext db = new BlockchainContext();
            var res = (from x in db.Game where x.Id == id select x).FirstOrDefault();
            ViewBag.game = res;
            return View();
        }

        public IActionResult GameEditPost(IFormCollection fc)
        {
            int id = int.Parse(fc["id"]);
            string name = fc["name"];
            string description = fc["description"];
            BlockchainContext db = new BlockchainContext();
            var res = (from x in db.Game where x.Id == id select x).FirstOrDefault();
            res.Name = name;
            res.Description = description;
            db.SaveChanges();
            return Redirect("/Game");
        }

       
    }
}
