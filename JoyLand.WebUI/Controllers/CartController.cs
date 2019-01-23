using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JoyLand.Domain.Entities;
using JoyLand.Domain.Abstract;
using JoyLand.WebUI.Models;
using System.ComponentModel.DataAnnotations;
using JoyLand.Domain.Concrete;
using System.Data.Entity;

namespace JoyLand.WebUI.Controllers
{
    public class CartController : Controller
    {
        private ISweetRepository repository;
        private ISDRepository orderProcessor;
        EFDbContext db = new EFDbContext();

        public CartController(ISweetRepository repo, ISDRepository processor)
        {
            repository = repo;
            orderProcessor = processor;
        }

        [HttpGet]
        public ActionResult Create(Cart cart, string returnUrl, ShoppingDetails shoppingDetails)
        {
            return View(new CartCreateViewModel
            {
                Cart = cart,
                ShoppingDetails = shoppingDetails,
                ReturnUrl = returnUrl
            });
        }
        [HttpPost]
        public ActionResult Create(Cart cart, ShoppingDetails shoppingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините, ваша корзина пуста!");
            }

            if (ModelState.IsValid)
            {
                db.Entry(shoppingDetails).State = EntityState.Added;
                db.SaveChanges();
                orderProcessor.SaveShoppingDetails(cart, shoppingDetails);
                cart.Clear();
                return View("Completed");
            }

            else
            {
                return View(shoppingDetails);
            }
        }
        public ActionResult List()
        {
            var shoppingDetails = db.ShoppingDetails.Include(p => p.Status);
            return View(shoppingDetails.ToList());
           // return View(db.ShoppingDetails);
        }


        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            // Находим в бд футболиста
            ShoppingDetails shoppingDetails = db.ShoppingDetails.Find(id);
            if (shoppingDetails != null)
            {
                // Создаем список команд для передачи в представление
                SelectList status = new SelectList(db.Status, "Id", "Name", shoppingDetails.StatusId);
                ViewBag.Status = status;
                return View(shoppingDetails);
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Edit(ShoppingDetails shoppingDetails)
        {
            db.Entry(shoppingDetails).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id = 0)
        {
            ShoppingDetails shoppingDetails = db.ShoppingDetails.Find(id);
            if (shoppingDetails == null)
            {
                return HttpNotFound();
            }
            return View(shoppingDetails);
        }

        //
        // POST: /Book/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ShoppingDetails shoppingDetails = db.ShoppingDetails.Find(id);
            db.ShoppingDetails.Remove(shoppingDetails);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
                {
                    Cart = cart,
                    ReturnUrl = returnUrl
                });
        }


        public RedirectToRouteResult AddToCart(Cart cart, int Id, string returnUrl)
        {
            Sweet sweet = repository.Sweets
                .FirstOrDefault(g => g.Id == Id);

            if (sweet != null)
            {
                cart.AddItem(sweet, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int Id, string returnUrl)
        {
            Sweet sweet = repository.Sweets
                .FirstOrDefault(g => g.Id == Id);

            if (sweet != null)
            {
                cart.RemoveLine(sweet);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
    }
}