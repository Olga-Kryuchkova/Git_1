using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JoyLand.WebUI.Infrastructure.Abstract;
using JoyLand.WebUI.Models;

namespace JoyLand.WebUI.Controllers
{
    public class AccountController : Controller
    {
        OurDbContext db = new OurDbContext();

        public ActionResult Index()
        {
            return View(db.userAccount);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            UserAccount user = db.userAccount.Find(id);
            if (user != null)
            {
                return View(user);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(UserAccount user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            UserAccount b = db.userAccount.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            UserAccount b = db.userAccount.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.userAccount.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        IAuthProvider authProvider;
        public AccountController(IAuthProvider auth)
        {
            authProvider = auth;
        }

        public ViewResult Login()          //для админа
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин или пароль");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if (ModelState.IsValid)
            {
                using (OurDbContext db = new OurDbContext())
                {
                    db.userAccount.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = "Пользователь " + account.FirstName + " " + account.LastName + " успешно зарегестрирован!";
            }
            return View();
        }

        //Логин
        public ActionResult LoginUs()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUs(UserAccount user)
        {
            using (OurDbContext db = new OurDbContext())
            {
                try
                {
                    var usr = db.userAccount.Single(u => u.UserName == user.UserName && u.Password == user.Password);
                    if (usr != null)
                    {
                        Session["UserId"] = usr.UserID.ToString();
                        Session["UserName"] = usr.UserName.ToString();
                        return RedirectToAction("LoggedIn");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Логин или пароль введены неверно!");
                    }
                }
                catch { ModelState.AddModelError("", "Логин или пароль введены неверно!"); }
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserId"]!=null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LoginUs");
            }
        }
    }
}