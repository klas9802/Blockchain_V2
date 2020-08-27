using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Myweb.Ef_model;

namespace Myweb.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            BlockchainContext db = new BlockchainContext();
            var res = (from x in db.User select x).ToList();
            ViewBag.users = res;
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
        public IActionResult AddUser(IFormCollection fc)
        {
            string name = fc["name"];
            string account = fc["account"];
            string password = fc["password"];
            BlockchainContext db = new BlockchainContext();
            User user = new User
            {
                Name = name,
                Account = account,
                Password = password,
            };
            db.User.Add(user);
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
        [HttpPost]
        public IActionResult Delete(int id)
        {
            BlockchainContext db = new BlockchainContext();
            var res = (from x in db.User where x.Id == id select x).FirstOrDefault();
            if (res == null)
            {
                return Content("Miss data");
            }
            else
            {
                db.User.Remove(res);
                db.SaveChanges();
                return Content("ok");
            }
        }

        public IActionResult UserEdit(int id)
        {
            BlockchainContext db = new BlockchainContext();
            var res = (from x in db.User where x.Id == id select x).FirstOrDefault();
            ViewBag.user = res;
            return View();
        }


        public IActionResult UserEditPost(IFormCollection fc) {
            int id = int.Parse(fc["id"]);
            string name = fc["name"];
            string account = fc["account"];
            string password = fc["password"];


            BlockchainContext db = new BlockchainContext();
            var res = (from x in db.User where x.Id == id select x).FirstOrDefault();
            

            res.Name = name;
            res.Account = account;
            res.Password = password;

            db.SaveChanges();
            return Redirect("/User");
        }
    }
}
